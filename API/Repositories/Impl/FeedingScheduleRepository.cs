using API.Helpers;
using API.Models;
using API.Models.Data;
using API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Stripe;

namespace API.Repositories.Impl
{
    public class FeedingScheduleRepository : IFeedingScheduleRepository
    {
        private readonly ZooManagementBackupContext _dbContext;

        public FeedingScheduleRepository(ZooManagementBackupContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CreateFeedingSchedule(FeedingSchedule feedingSchedule)
        {
            if (feedingSchedule == null) return false;  
            await _dbContext.FeedingSchedules.AddAsync(feedingSchedule);
            return await Save();
        }

        public async Task<FeedingSchedule> GetFeedingSchedule(int no)
        {
            return await _dbContext.FeedingSchedules
                .Include(fs => fs.FeedingMenu)
                .Include(fs => fs.Animal)
                .Include(fs => fs.Cage)
                .Include(fs => fs.Employee)
                .FirstOrDefaultAsync(fs => fs.No == no);
        }

        public async Task<IEnumerable<FeedingSchedule>> GetFeedingSchedules()
        {
            return await _dbContext.FeedingSchedules
                .Include(fs => fs.FeedingMenu)
                .Include(fs => fs.Animal)
                .Include(fs => fs.Cage)
                .Include(fs => fs.Employee)
                .OrderByDescending(fs => fs.No)
                .ToListAsync();
        }

        public async Task<IEnumerable<FeedingSchedule>> GetFeedingSchedulesByAnimal(string animalId)
        {
            return await _dbContext.FeedingSchedules
                .Include(fs => fs.FeedingMenu)
                .Include(fs => fs.Animal)
                .Include(fs => fs.Cage)
                .Include(fs => fs.Employee)
                .Where(fs => fs.AnimalId.ToLower().Equals(animalId.ToLower().Trim()))
                .OrderByDescending(fs => fs.No)
                .ToListAsync();
        }

        public async Task<IEnumerable<FeedingSchedule>> GetFeedingSchedulesByCage(string cageId)
        {
            return await _dbContext.FeedingSchedules
                .Include(fs => fs.FeedingMenu)
                .Include(fs => fs.Animal)
                .Include(fs => fs.Cage)
                .Include(fs => fs.Employee)
                .Where(fs => fs.CageId.ToLower().Equals(cageId.ToLower().Trim()))
                .OrderByDescending(fs => fs.No)
                .ToListAsync();
        }

        public async Task<double> GetMaxFeedingQuantityOnAnimal(string animalId)
        {
            var animal = _dbContext.Animals.Find(animalId);
            return await Task.FromResult(animal.MaxFeedingQuantity);
        }

        public async Task<double> GetMaxFeedingQuantityOnCage(string cageId)
        {
            var animals = await _dbContext.Animals
                .Where(a => a.CageId.ToLower() == cageId.ToLower())
                .ToListAsync();
            
            if (!animals.Any()) return 0;

            double avgFeedingQuantity = animals
                .Select(a => (double)a.MaxFeedingQuantity)
                .Average();
            return avgFeedingQuantity;
        }

        public async Task<bool> Save()
        {
            var saved = _dbContext.SaveChangesAsync();
            return await saved > 0;
        }

        public async Task<bool> UpdateFeedingScheduleStatus(FeedingSchedule feedingSchedule)
        {
            var existingFeedingSchedule = await GetFeedingSchedule(feedingSchedule.No);
            if (existingFeedingSchedule == null) return false;

            existingFeedingSchedule.FeedingStatus = feedingSchedule.FeedingStatus;
            if (existingFeedingSchedule.FeedingStatus == FeedingScheduleConstraints.FEEDING_STATUS_COMPLETED)
            {
                var feedingFood = await _dbContext.FoodInventories
                    .FindAsync(existingFeedingSchedule.FeedingMenu.FoodId);
                if (feedingFood == null) return false;
                // get the current food quantity in food inventory
                var currentFoodQuantity = feedingFood.InventoryQuantity;
                var feedingQuantity = existingFeedingSchedule.FeedingAmount;
                var updatedFoodQuantity = currentFoodQuantity - feedingQuantity;

                feedingFood.InventoryQuantity = updatedFoodQuantity;
                _dbContext.FoodInventories.Update(feedingFood);
            }
            _dbContext.FeedingSchedules.Update(existingFeedingSchedule);
            return await Save();
        }
    }
}
