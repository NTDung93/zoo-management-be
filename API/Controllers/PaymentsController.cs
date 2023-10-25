using API.Models.Dtos;
using API.Models.Entities;
using API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using Stripe;
using Stripe.Checkout;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class PaymentsController : BaseApiController
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IOrderDetailRepository _orderDetailRepo;
        private readonly ITransactionHistoriesRepository _transactionHistoriesRepo;
        private readonly IMapper _mapper;

        // This is your Stripe CLI webhook secret for testing your endpoint locally.
        string endpointSecret;

        public PaymentsController(IOrderRepository orderRepo, IOrderDetailRepository orderDetailRepo, ITransactionHistoriesRepository transactionHistoriesRepo, IMapper mapper)
        {
            this._orderRepo = orderRepo;
            this._orderDetailRepo = orderDetailRepo;
            this._transactionHistoriesRepo = transactionHistoriesRepo;
            this._mapper = mapper;
            StripeConfiguration.ApiKey = "sk_test_51O0Q9dIJ9Gk875gHXSiRb0q7vd9gnVkH44y3kmw6SBCpVWVIgkknKv6yvaCiebsYhoiFfBkNkygA1AgSvGzXEDLs00zzatOZQ2";
        }

        [HttpPost("create-order")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> createTransaction([FromBody] OrderDto orderDto)
        {
            //create new order
            //remove blank character from begin and last of every element in orderDto
            orderDto.FullName = orderDto.FullName.Trim();
            orderDto.PhoneNumber = orderDto.PhoneNumber.Trim();
            orderDto.Email = orderDto.Email.Trim();

            var order = _mapper.Map<Order>(orderDto);
            var newOrder = await _orderRepo.CreateOrder(order);

            //create new order details
            var orderDetails = new List<OrderDetail>();
            foreach (OrderDetail cartItem in order.OrderDetails)
            {
                var orderDetail = new OrderDetail
                {
                    OrderId = newOrder.OrderId,
                    TicketId = cartItem.TicketId,
                    Quantity = cartItem.Quantity,
                    EntryDate = cartItem.EntryDate,
                    UnitTotalPrice = (double)cartItem.UnitTotalPrice
                };
                orderDetails.Add(orderDetail);
                //_orderDetailRepo.CreateSingleOrderDetail(orderDetail);
            }
            _orderDetailRepo.CreateOrderDetails(orderDetails);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok("Create order and order details sucessfully!");
        }

        [HttpPost("create-checkout-session")]
        [ProducesResponseType(200)]
        public ActionResult CreateCheckoutSession(List<CartItemRequest> cartItems)
        {
            var lineItems = new List<SessionLineItemOptions>();
            cartItems.ForEach(cartItem =>
            {
                var lineItem = new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmount = (long)cartItem.ticket.UnitPrice,
                        Currency = "vnd",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = cartItem.ticket.Type,
                            Images = new List<string> { cartItem.ticket.Image },
                        },
                    },
                    Quantity = cartItem.quantity,
                };

                lineItems.Add(lineItem);
            });

            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string>
                {
                  "card",
                },
                LineItems = lineItems,
                PhoneNumberCollection = new SessionPhoneNumberCollectionOptions { Enabled = true },
                InvoiceCreation = new SessionInvoiceCreationOptions { Enabled = true },
                Mode = "payment",
                SuccessUrl = "http://localhost:5173/checkout-success",
                CancelUrl = "http://localhost:5173/cart",
            };

            var service = new SessionService();
            Session session = service.Create(options);
            return Ok(session.Url);
        }

        [HttpPost("webhook")]
        public async Task<IActionResult> Index()
        {
            endpointSecret = "whsec_f37c5bfcd5ea35cb9e9b6ab576c3d7ca8f50f1fe32fd2df22f759dde60f907f2";
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();

            if (endpointSecret != "")
            {
                try
                {
                    var stripeEvent = EventUtility.ConstructEvent(json,
                   Request.Headers["Stripe-Signature"], endpointSecret);
                    var data = stripeEvent.Data.Object;
                    var eventType = stripeEvent.Type;

                    // Handle the event
                    if (stripeEvent.Type == Events.PaymentIntentSucceeded)
                    {
                    }
                    // ... handle other event types
                    else if (stripeEvent.Type == Events.CheckoutSessionCompleted)
                    {
                        //log the event
                        Console.WriteLine("Checkout session completed!");
                        Console.WriteLine(json);

                        var session = stripeEvent.Data.Object as Session;

                        //get list of orders
                        var orders = await _orderRepo.GetOrders();
                        var lastestOrder = orders.FirstOrDefault();

                        //create new transaction history
                        var transaction = new TransactionHistory
                        {
                            PaymentMethod = "Credit Card",
                            TotalPrice = session.AmountTotal,
                            PurchaseDate = DateTime.Now,
                            PaymentStatus = 1,
                            OrderId = lastestOrder.OrderId,
                        };
                        Console.WriteLine("Transaction total:");
                        Console.WriteLine(transaction.TotalPrice);
                        await _transactionHistoriesRepo.CreateTransaction(transaction);
                    }
                    else
                    {
                        Console.WriteLine("Unhandled event type: {0}", stripeEvent.Type);
                    }
                    
                }
                catch (StripeException e)
                {
                    return BadRequest();
                }
            }
            else
            {
                var data = Request.Body.ReadByte;
                var eventType = Request.Body.GetType;
            }
            return Ok();
        }
    }
}
