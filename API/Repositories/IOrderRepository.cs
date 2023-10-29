using API.Models.Entities;

namespace API.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> CreateOrder(Order order);
        Task<IEnumerable<Order>> GetOrders();
        Task<IEnumerable<Order>> GetOrdersWithOrderDetails();

    }
}
