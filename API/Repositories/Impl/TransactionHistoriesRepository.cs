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
            await _context.TransactionHistories.AddAsync(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TransactionHistory>> GetTransactions()
        {
            return await _context.TransactionHistories.Include(x=>x.Order).OrderBy(a => a.TransactionId).ToListAsync();
        }
    }
}
