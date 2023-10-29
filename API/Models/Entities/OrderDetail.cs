namespace API.Models.Entities
{
    public class OrderDetail
    {
        public int? Quantity { get; set; }
        public DateTime? EntryDate { get; set; }
        public double UnitTotalPrice { get; set; }
        public int OrderId { get; set; }
        public string TicketId { get; set; }
        public Order Order { get; set; }
        public Ticket Ticket { get; set; }
    }
}
