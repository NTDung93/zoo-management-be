using API.Models.Entities;

namespace API.Repositories
{
    public interface ITransactionHistoriesRepository
    {
        Task CreateTransaction(TransactionHistory transaction);
        Task<IEnumerable<TransactionHistory>> GetTransactions();
    }
}
