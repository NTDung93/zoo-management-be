namespace API.Models.Entities
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public string Type { get; set; }
        public decimal? UnitPrice { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
