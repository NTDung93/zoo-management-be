using API.Models.Data;
using API.Models.Dtos;
using API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Impl
{
    public class ImportHistoryRepository : IImportHistoryRepository
    {
        private readonly ZooManagementBackupContext _dbContext;

        public ImportHistoryRepository(ZooManagementBackupContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ImportHistory>> GetImportHistories()
        {
            return await _dbContext.ImportHistories.Include(ih => ih.FoodInventory)
                .OrderByDescending(ih => ih.No)
                .ToListAsync();
        }
            
        public async Task<bool> ImportAFood(ImportHistory importHistory)
        {
            var food = _dbContext.FoodInventories.Find(importHistory.FoodId);
            if (food == null) return false;

            await _dbContext.ImportHistories.AddAsync(importHistory);

            food.InventoryQuantity += importHistory.ImportQuantity;
            _dbContext.FoodInventories.Update(food);
            return await Save();
        }

        public async Task<bool> Save()
        {
            var saved = _dbContext.SaveChangesAsync();
            return await saved > 0;
        }
    }
}
