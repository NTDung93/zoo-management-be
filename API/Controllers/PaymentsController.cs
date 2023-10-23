using API.Models.Dtos;
using API.Models.Entities;
using API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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

        public PaymentsController(IOrderRepository orderRepo, IOrderDetailRepository orderDetailRepo, ITransactionHistoriesRepository transactionHistoriesRepo, IMapper mapper)
        {
            this._orderRepo = orderRepo;
            this._orderDetailRepo = orderDetailRepo;
            this._transactionHistoriesRepo = transactionHistoriesRepo;
            this._mapper = mapper;
            StripeConfiguration.ApiKey = "sk_test_51O0Q9dIJ9Gk875gHXSiRb0q7vd9gnVkH44y3kmw6SBCpVWVIgkknKv6yvaCiebsYhoiFfBkNkygA1AgSvGzXEDLs00zzatOZQ2";
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
                InvoiceCreation = new SessionInvoiceCreationOptions { Enabled = true },
                Mode = "payment",
                SuccessUrl = "http://localhost:5173/checkout-success",
                CancelUrl = "http://localhost:5173/cart",
            };

            var service = new SessionService();
            Session session = service.Create(options);
            return Ok(session.Url);
        }

        [HttpPost("create-transaction")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> createTransaction([FromBody] OrderDto orderDto)
        {
            //create new order
            var order = _mapper.Map<Order>(orderDto);
            var newOrder = await _orderRepo.CreateOrder(order);

            //create new order details
            var orderDetails = new List<OrderDetail>();
            foreach(OrderDetail cartItem in order.OrderDetails)
            {
                var orderDetail = new OrderDetail
                {
                    OrderId = newOrder.OrderId,
                    TicketId = cartItem.TicketId,
                    Quantity = cartItem.Quantity,
                    EntryDate = cartItem.EntryDate,
                    UnitTotalPrice = (double)(cartItem.UnitTotalPrice * cartItem.Quantity)
                };
                //orderDetails.Add(orderDetail);
                await _orderDetailRepo.CreateSingleOrderDetail(orderDetail);
            }
            //await _orderDetailRepo.CreateOrderDetails(orderDetails);

            //create new transaction history
            double totalPrices = 0;
            orderDetails.ForEach(orderDetail =>
            {
                totalPrices += orderDetail.UnitTotalPrice;
            });

            var transaction = new TransactionHistory
            {
                PaymentMethod = "Credit Card",
                TotalPrice = (decimal?)totalPrices,
                PurchaseDate = DateTime.Now,
                PaymentStatus = 0,
                OrderId = newOrder.OrderId,
            };
            await _transactionHistoriesRepo.CreateTransaction(transaction);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok("Create order details, order and transaction sucessfully!");
        }
    }
}
