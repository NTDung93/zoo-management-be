using API.Models.Entities;

namespace API.Repositories
{
    public interface IOrderDetailRepository
    {
        Task CreateOrderDetails(List<OrderDetail> orderDetails);
        Task CreateSingleOrderDetail(OrderDetail orderDetail);
        Task<IEnumerable<OrderDetail>> GetOrderDetails();
        Task<IEnumerable<OrderDetail>> GetOrderDetailsByOrderId(int orderId);
    }
}
