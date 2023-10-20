using API.Models.Entities;

namespace API.Models.Dtos
{
    public class TransactionHistoryDto
    {
        public int TransactionId { get; set; }
        public string PaymentMethod { get; set; }
        public decimal? TotalPrice { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public byte? PaymentStatus { get; set; }
        public int OrderId { get; set; }
        public OrderDto Order { get; set; }
    }
}
