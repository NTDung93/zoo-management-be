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

        public async Task<Order> CreateOrder(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            var createdOrder = await _context.Orders
              .OrderByDescending(o => o.OrderId)
              .FirstOrDefaultAsync();

            return createdOrder;
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await _context.Orders.OrderByDescending(x=>x.OrderId).ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersWithOrderDetails()
        {
            return await _context.Orders.Include(x => x.OrderDetails).OrderByDescending(x => x.OrderId).ToListAsync();
        }
    }
}
