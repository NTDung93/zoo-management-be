namespace API.Models.Entities
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int? Quantity { get; set; }
        public DateTime? EntryDate { get; set; }
        public int OrderId { get; set; }
        public int TicketId { get; set; }
        public Order Order { get; set; }
        public Ticket Ticket { get; set; }
    }
}
