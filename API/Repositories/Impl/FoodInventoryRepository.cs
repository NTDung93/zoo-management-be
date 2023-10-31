using API.Models.Data;
using API.Models.Dtos;
using API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Impl
{
    public class FoodInventoryRepository : IFoodInventoryRepository
    {
        private readonly ZooManagementBackupContext _dbContext;

        public FoodInventoryRepository(ZooManagementBackupContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CreateFood(FoodInventory food)
        {
            if (food == null) return false;
            food.CreatedDate = DateTimeOffset.Now;
            await _dbContext.FoodInventories.AddAsync(food);
            return await Save();
        }

        public async Task<bool> DeleteFood(string id)
        {
            var food = await GetFood(id);
            if (food == null) return false;
            
            // check if food has any records in ImportHistories table
            // if yes, cannot delete this food
            var isExisted = await _dbContext.ImportHistories
                .AnyAsync(ih => ih.FoodId.Equals(id));
            if (isExisted) return false;

            _dbContext.FoodInventories.Remove(food);
            return await Save();
        }

        public async Task<bool> FindFoodInScheduleMenu(string foodId)
        {
            return await _dbContext.FeedingMenus
                .AnyAsync(fm => fm.FoodId.Equals(foodId));
        }

        public async Task<FoodInventory> GetFood(string id)
        {
            return await _dbContext.FoodInventories.FindAsync(id);
        }

        public async Task<IEnumerable<FoodInventory>> GetFoods()
        {
            return await _dbContext.FoodInventories
                .OrderByDescending(f => f.CreatedDate)
                .ToListAsync();
        }

        public async Task<bool> Save()
        {
            var saved = _dbContext.SaveChangesAsync();
            return await saved > 0;
        }

        public async Task<IEnumerable<FoodInventory>> SearchFoodByName(string name)
        {
            return await _dbContext.FoodInventories
                .Where(f => f.FoodName.ToLower().Trim().Contains(name.Trim().ToLower()))
                .ToListAsync();
        }

        public async Task<bool> UpdateFood(FoodInventoryRequest food)
        {
            var existingFood = await GetFood(food.FoodId);
            if (existingFood == null) return false;

            existingFood.FoodName = food.FoodName;
            existingFood.CreatedDate = DateTimeOffset.Now;
            _dbContext.FoodInventories.Update(existingFood);
            return await Save();
        }
    }
}
