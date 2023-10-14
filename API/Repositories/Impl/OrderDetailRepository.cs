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
        public async Task<IEnumerable<OrderDetail>> GetOrderDetails()
        {
            return await _context.OrderDetails.Include(y=>y.Order).Include(z=>z.Ticket).OrderBy(x=>x.OrderDetailId).ToListAsync();
        }
    }
}
