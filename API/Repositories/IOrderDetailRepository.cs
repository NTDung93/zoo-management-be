using API.Models.Entities;

namespace API.Repositories
{
    public interface IOrderDetailRepository
    {
        Task<IEnumerable<OrderDetail>> GetOrderDetails();
    }
}
