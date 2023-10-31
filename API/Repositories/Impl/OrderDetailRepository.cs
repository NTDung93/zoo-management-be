using API.Models.Data;
using API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Impl
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly ZooManagementBackupContext _context;
        public OrderDetailRepository(ZooManagementBackupContext context)
        {
            _context = context;
        }

        public async Task CreateOrderDetails(List<OrderDetail> orderDetails)
        {
            await _context.OrderDetails.AddRangeAsync(orderDetails);
            await _context.SaveChangesAsync();
        }

        public async Task CreateSingleOrderDetail(OrderDetail orderDetail)
        {
            _context.OrderDetails.Add(orderDetail);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<OrderDetail>> GetOrderDetails()
        {
            return await _context.OrderDetails.Include(z=>z.Ticket).ToListAsync();
        }

        public async Task<IEnumerable<OrderDetail>> GetOrderDetailsByOrderId(int orderId)
        {
            return await _context.OrderDetails.Where(z => z.OrderId == orderId).Include(z=>z.Ticket).ToListAsync();
        }
    }
}
