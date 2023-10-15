namespace API.Models.Entities
{
    public class Ticket
    {
        public string TicketId { get; set; }
        public string Type { get; set; }
        public decimal? UnitPrice { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
