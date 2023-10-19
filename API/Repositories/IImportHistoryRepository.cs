using API.Models.Dtos;
using API.Models.Entities;

namespace API.Repositories
{
    public interface IImportHistoryRepository
    {
        Task<IEnumerable<ImportHistory>> GetImportHistories();
        Task<bool> ImportAFood(ImportHistory importHistory);
        Task<bool> Save();
    }
}
