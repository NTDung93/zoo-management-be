using API.Models.Entities;

namespace API.Repositories
{
    public interface ITransactionHistoriesRepository
    {
        Task<IEnumerable<TransactionHistory>> GetTransactions();
    }
}
