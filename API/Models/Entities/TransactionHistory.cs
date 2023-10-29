namespace API.Models.Entities
{
    public class TransactionHistory
    {
        public int TransactionId { get; set; }
        public string PaymentMethod { get; set; }
        public decimal? TotalPrice { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public byte? PaymentStatus { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
