using API.Models.Data;
using API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Impl
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ZooManagementBackupContext _context;

        public OrderRepository(ZooManagementBackupContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await _context.Orders.OrderBy(x=>x.OrderId).ToListAsync();
        }
    }
}
