namespace API.Models.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public TransactionHistory TransactionHistory { get; set; }
    }
}
