using API.Models.Data;
using API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Impl
{
    public class TransactionHistoriesRepository : ITransactionHistoriesRepository
    {
        private readonly ZooManagementBackupContext _context;
        public TransactionHistoriesRepository(ZooManagementBackupContext context)
        {
            _context = context;
        }

        public async Task CreateTransaction(TransactionHistory transaction)
        {
            _context.TransactionHistories.Add(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task<TransactionHistory> GetTransactionByOrderId(int orderId)
        {
            return await _context.TransactionHistories.FirstOrDefaultAsync(x => x.OrderId == orderId);
        }

        public async Task<IEnumerable<TransactionHistory>> GetTransactions()
        {
            return await _context.TransactionHistories.Include(x=>x.Order.OrderDetails).OrderBy(a => a.TransactionId).ToListAsync();
        }
    }
}
