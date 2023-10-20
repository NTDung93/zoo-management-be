using API.Models.Entities;

namespace API.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetOrders();
    }
}
