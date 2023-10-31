namespace API.Models.Dtos
{
    public class CartItemRequest
    {
        public TicketDto ticket { get; set; }
        public int quantity { get; set; }
        public DateTime? entryDate { get; set; }
    }
}
