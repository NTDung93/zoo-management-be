using API.Models.Entities;

namespace API.Models.Dtos
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<OrderDetailDto> OrderDetails { get; set; }
    }
}
