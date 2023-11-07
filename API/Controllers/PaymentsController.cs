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
using System;
using System.Net;
using System.Net.Mail;
using System.Text;

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

                        //Console.WriteLine("<<<<<<<<<Order :");
                        var listOrderDetails = await _orderDetailRepo.GetOrderDetailsByOrderId(lastestOrder.OrderId);

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

                        //get transaction history by order id
                        var transactionHistory = await _transactionHistoriesRepo.GetTransactionByOrderId(lastestOrder.OrderId);

                        var htmlCode = "<!DOCTYPE html>" +
                            "<html lang=\"en, id\">" +
                            "  <head>" +
                            "    <meta charset=\"UTF-8\" />" +
                            "    <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\" />" +
                            "    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\" />" +
                            "" +
                            "    <link" +
                            "      href=\"https://fonts.googleapis.com/css2?family=Inter:wght@100;200;300;400;500;600;700;800;900&display=swap\"" +
                            "      rel=\"stylesheet\"" +
                            "    />" +
                            "" +
                            "<style>" +
                            "@import \"https://fonts.googleapis.com/css2?family=Inter:wght@100;200;300;400;500;600;700;800;900&display=swap\";" +
                            "* {" +
                            "  margin: 0 auto;" +
                            "  padding: 0 auto;" +
                            "  user-select: none;" +
                            "}" +
                            "" +
                            "body {" +
                            "  padding: 20px;" +
                            "  font-family: \"Inter\", -apple-system, BlinkMacSystemFont, \"Segoe UI\", Roboto, Oxygen, Ubuntu, Cantarell, \"Open Sans\", \"Helvetica Neue\", sans-serif;" +
                            "  -webkit-font-smoothing: antialiased;" +
                            "  background-color: #dcdcdc;" +
                            "}" +
                            "" +
                            ".wrapper-invoice {" +
                            "  display: flex;" +
                            "  justify-content: center;" +
                            "}" +
                            ".wrapper-invoice .invoice {" +
                            "  height: auto;" +
                            "  background: #fff;" +
                            "  padding: 5vh;" +
                            "  margin-top: 5vh;" +
                            "  max-width: 110vh;" +
                            "  width: 100%;" +
                            "  box-sizing: border-box;" +
                            "  border: 1px solid #dcdcdc;" +
                            "}" +
                            ".wrapper-invoice .invoice .invoice-information {" +
                            "  float: right;" +
                            "  text-align: right;" +
                            "}" +
                            ".wrapper-invoice .invoice .invoice-information b {" +
                            "  color: \"#0F172A\";" +
                            "}" +
                            ".wrapper-invoice .invoice .invoice-information p {" +
                            "  font-size: 2vh;" +
                            "  color: gray;" +
                            "}" +
                            ".wrapper-invoice .invoice .invoice-logo-brand h2 {" +
                            "  text-transform: uppercase;" +
                            "  font-family: \"Inter\", -apple-system, BlinkMacSystemFont, \"Segoe UI\", Roboto, Oxygen, Ubuntu, Cantarell, \"Open Sans\", \"Helvetica Neue\", sans-serif;" +
                            "  font-size: 2.9vh;" +
                            "  color: \"#0F172A\";" +
                            "}" +
                            ".wrapper-invoice .invoice .invoice-logo-brand img {" +
                            "  max-width: 100px;" +
                            "  width: 100%;" +
                            "  object-fit: fill;" +
                            "}" +
                            ".wrapper-invoice .invoice .invoice-head {" +
                            "  display: flex;" +
                            "  margin-top: 8vh;" +
                            "}" +
                            ".wrapper-invoice .invoice .invoice-head .head {" +
                            "  width: 100%;" +
                            "  box-sizing: border-box;" +
                            "}" +
                            ".wrapper-invoice .invoice .invoice-head .client-info {" +
                            "  text-align: left;" +
                            "}" +
                            ".wrapper-invoice .invoice .invoice-head .client-info h2 {" +
                            "  font-weight: 500;" +
                            "  letter-spacing: 0.3px;" +
                            "  font-size: 2vh;" +
                            "  color: \"#0F172A\";" +
                            "}" +
                            ".wrapper-invoice .invoice .invoice-head .client-info p {" +
                            "  font-size: 2vh;" +
                            "  color: gray;" +
                            "}" +
                            ".wrapper-invoice .invoice .invoice-head .client-data {" +
                            "  text-align: right;" +
                            "}" +
                            ".wrapper-invoice .invoice .invoice-head .client-data h2 {" +
                            "  font-weight: 500;" +
                            "  letter-spacing: 0.3px;" +
                            "  font-size: 2vh;" +
                            "  color: \"#0F172A\";" +
                            "}" +
                            ".wrapper-invoice .invoice .invoice-head .client-data p {" +
                            "  font-size: 2vh;" +
                            "  color: gray;" +
                            "}" +
                            ".wrapper-invoice .invoice .invoice-body {" +
                            "  margin-top: 8vh;" +
                            "}" +
                            ".wrapper-invoice .invoice .invoice-body .table {" +
                            "  border-collapse: collapse;" +
                            "  width: 100%;" +
                            "}" +
                            ".wrapper-invoice .invoice .invoice-body .table thead tr th {" +
                            "  font-size: 2vh;" +
                            "  border: 1px solid #dcdcdc;" +
                            "  text-align: left;" +
                            "  padding: 1vh;" +
                            "  background-color: #eeeeee;" +
                            "}" +
                            ".wrapper-invoice .invoice .invoice-body .table tbody tr td {" +
                            "  font-size: 2vh;" +
                            "  border: 1px solid #dcdcdc;" +
                            "  text-align: left;" +
                            "  padding: 1vh;" +
                            "  background-color: #fff;" +
                            "}" +
                            ".wrapper-invoice .invoice .invoice-body .table tbody tr td:nth-child(2) {" +
                            "  text-align: right;" +
                            "}" +
                            ".wrapper-invoice .invoice .invoice-body .flex-table {" +
                            "  display: flex;" +
                            "}" +
                            ".wrapper-invoice .invoice .invoice-body .flex-table .flex-column {" +
                            "  width: 100%;" +
                            "  box-sizing: border-box;" +
                            "}" +
                            ".wrapper-invoice .invoice .invoice-body .flex-table .flex-column .table-subtotal {" +
                            "  border-collapse: collapse;" +
                            "  box-sizing: border-box;" +
                            "  width: 100%;" +
                            "  margin-top: 2vh;" +
                            "}" +
                            ".wrapper-invoice .invoice .invoice-body .flex-table .flex-column .table-subtotal tbody tr td {" +
                            "  font-size: 2vh;" +
                            "  border-bottom: 1px solid #dcdcdc;" +
                            "  text-align: left;" +
                            "  padding: 1vh;" +
                            "  background-color: #fff;" +
                            "}" +
                            ".wrapper-invoice .invoice .invoice-body .flex-table .flex-column .table-subtotal tbody tr td:nth-child(2) {" +
                            "  text-align: right;" +
                            "}" +
                            ".wrapper-invoice .invoice .invoice-body .invoice-total-amount {" +
                            "  margin-top: 1rem;" +
                            "}" +
                            ".wrapper-invoice .invoice .invoice-body .invoice-total-amount p {" +
                            "  font-weight: bold;" +
                            "  color: \"#0F172A\";" +
                            "  text-align: right;" +
                            "  font-size: 2vh;" +
                            "}" +
                            ".wrapper-invoice .invoice .invoice-footer {" +
                            "  margin-top: 4vh;" +
                            "}" +
                            ".wrapper-invoice .invoice .invoice-footer p {" +
                            "  font-size: 1.7vh;" +
                            "  color: gray;" +
                            "}" +
                            "" +
                            ".copyright {" +
                            "  margin-top: 2rem;" +
                            "  text-align: center;" +
                            "}" +
                            ".copyright p {" +
                            "  color: gray;" +
                            "  font-size: 1.8vh;" +
                            "}" +
                            "" +
                            "@media print {" +
                            "  .table thead tr th {" +
                            "    -webkit-print-color-adjust: exact;" +
                            "    background-color: #eeeeee !important;" +
                            "  }" +
                            "" +
                            "  .copyright {" +
                            "    display: none;" +
                            "  }" +
                            "}" +
                            ".rtl {" +
                            "  direction: rtl;" +
                            "  font-family: \"Inter\", -apple-system, BlinkMacSystemFont, \"Segoe UI\", Roboto, Oxygen, Ubuntu, Cantarell, \"Open Sans\", \"Helvetica Neue\", sans-serif;" +
                            "}" +
                            ".rtl .invoice-information {" +
                            "  float: left !important;" +
                            "  text-align: left !important;" +
                            "}" +
                            ".rtl .invoice-head .client-info {" +
                            "  text-align: right !important;" +
                            "}" +
                            ".rtl .invoice-head .client-data {" +
                            "  text-align: left !important;" +
                            "}" +
                            ".rtl .invoice-body .table thead tr th {" +
                            "  text-align: right !important;" +
                            "}" +
                            ".rtl .invoice-body .table tbody tr td {" +
                            "  text-align: right !important;" +
                            "}" +
                            ".rtl .invoice-body .table tbody tr td:nth-child(2) {" +
                            "  text-align: left !important;" +
                            "}" +
                            ".rtl .invoice-body .flex-table .flex-column .table-subtotal tbody tr td {" +
                            "  text-align: right !important;" +
                            "}" +
                            ".rtl .invoice-body .flex-table .flex-column .table-subtotal tbody tr td:nth-child(2) {" +
                            "  text-align: left !important;" +
                            "}" +
                            ".rtl .invoice-body .invoice-total-amount p {" +
                            "  text-align: left !important;" +
                            "}" +
                            "" +
                            "/*# sourceMappingURL=invoice.css.map */" +
                            "</style>" +
                            "  </head>" +
                            "  <body>" +
                            "    <section class=\"wrapper-invoice\">" +
                            "      <!-- switch mode rtl by adding class rtl on invoice class -->" +
                            "      <div class=\"invoice\">" +
                            "        <div class=\"invoice-information\">" +
                            "          <p><b>Created Date: </b>" + DateTime.Now.ToString("MMMM dd, yyyy") + "</p>" +
                            "        </div>" +
                            "        <!-- logo brand invoice -->" +
                            "        <div class=\"invoice-logo-brand\">" +
                            "          <!-- <h2>Tampsh.</h2> -->" +
                            "          <img src=\"https://res.cloudinary.com/dnk5fcjhn/image/upload/v1696070552/logo/dsfsinb1tzz9q1drdqoe.png\" alt=\"\" />" +
                            "        </div>" +
                            "        <!-- invoice head -->" +
                            "        <div class=\"invoice-head\">" +
                            "          <div class=\"head client-info\">" +
                            "            <p>Name: " +
                            "            <p>Phone: " +
                            "            <p>Email: </p>" +
                            "            <p>Purchase: </p>" +
                            "          </div>" +
                            "          <div class=\"head client-data\">" +
                            "            <p>" + lastestOrder.FullName + "</p>" +
                            "            <p>" + lastestOrder.PhoneNumber + "</p>" +
                            "            <p>" + lastestOrder.Email + "</p>" +
                            "          <p>" + DateTime.Now.ToString("MMMM dd, yyyy") + "</p>" +
                            "          </div>" +
                            "        </div>" +
                            "        <!-- invoice body-->" +
                            "        <div class=\"invoice-body\">" +
                            "          <table class=\"table\">" +
                            "            <thead>" +
                            "              <tr>" +
                        "                <th></th>" +
                        "                <th style=\"text-align: center;\">Type</th>" +
                        "                <th style=\"text-align: center;\">Quantity</th>" +
                        "                <th style=\"text-align: center;\">Entry date</th>" +
                        "                <th style=\"text-align: center;\">Unit price</th>" +
                        "              </tr>" +
                            "            </thead>" +
                            "            <tbody>";
                        //"              <tr>" +
                        //"                <td>Template Invoice</td>" +
                        //"                <td>Rp.75.000</td>" +
                        //"              </tr>" +
                        //"              <tr>" +
                        //"                <td>tax</td>" +
                        //"                <td>Rp.5.000</td>" +
                        //"              </tr>" +

                        foreach (var orderDetail in listOrderDetails)
                        {
                            htmlCode += "              <tr>" +
                                           "                <td style=\"text-align: center;\"><img src=\"" + orderDetail.Ticket.Image + "\" width=\"100\" height=\"100\"></td>" +
                                           "                <td style=\"text-align: center;\">" + orderDetail.Ticket.Type + "</td>" +
                                           "                <td style=\"text-align: center;\">" + orderDetail.Quantity + "</td>" +
                                           "                <td style=\"text-align: center;\">" + orderDetail.EntryDate.ToString().Substring(0, 10) + "</td>" +
                                           "                <td style=\"text-align: center;\">" + orderDetail.Ticket.UnitPrice + " vnd</td>" +
                                           "              </tr>";
                        }

                        htmlCode += " </tbody>" +
                            "          </table>" +
                            "          <!-- invoice total  -->" +
                            "          <div class=\"invoice-total-amount\">" +
                            "            <p>Total: " + session.AmountTotal + " vnd</p>" +
                            "          </div>" +
                            "        </div>" +
                            "        <!-- invoice footer -->" +
                            "        <div class=\"invoice-footer\">" +
                            "          <p>Thank you, we are so happy to see you at AmaZoo!</p>" +
                            " <br/>" +
                            "          <p>Please give this QR code below to our staff to check in at the entrance!</p>" +
                            "           <img src=\"https://api.qrserver.com/v1/create-qr-code/?data=" + transactionHistory.TransactionId + ", " + lastestOrder.OrderId + "\" alt=\"QR Code for amazoo@gmail.com\" />" +
                            "        </div>" +
                            "      </div>" +
                            "    </section>" +
                            "  </body>" +
                            "</html>";

                        string smtpServer = "smtp.office365.com";
                        int smtpPort = 587; // Gmail SMTP port
                        string smtpUsername = "funnyamazoo@outlook.com";
                        string smtpPassword = "Amahahaha@123";

                        SmtpClient smtpClient = new SmtpClient(smtpServer);
                        smtpClient.Port = smtpPort;
                        smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                        smtpClient.EnableSsl = true; // Use SSL for secure connection

                        MailMessage mailMessage = new MailMessage
                        {
                            From = new MailAddress(smtpUsername),
                            Subject = "Thanks for buying our zoo tickets!",
                            IsBodyHtml = true,
                            Body = htmlCode

                        };
                        //mailMessage.To.Add(lastestOrder.Email);

                        mailMessage.To.Add(lastestOrder.Email);

                        try
                        {
                            smtpClient.Send(mailMessage);
                            Console.WriteLine("Email sent successfully!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Email could not be sent. Error: " + ex.Message);
                        }
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
