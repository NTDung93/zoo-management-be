using API.Models;
using API.Models.Data;
using API.Models.Entities;
using Microsoft.EntityFrameworkCore;

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
                .FirstOrDefaultAsync(fs => fs.No == no);
        }

        public async Task<IEnumerable<FeedingSchedule>> GetFeedingSchedules()
        {
            return await _dbContext.FeedingSchedules
                .Include(fs => fs.FeedingMenu)
                .Include(fs => fs.Animal)
                .Include(fs => fs.Cage)
                .OrderByDescending(fs => fs.No)
                .ToListAsync();
        }

        public async Task<IEnumerable<FeedingSchedule>> GetFeedingSchedulesByAnimal(string animalId)
        {
            return await _dbContext.FeedingSchedules
                .Include(fs => fs.FeedingMenu)
                .Include(fs => fs.Animal)
                .Include(fs => fs.Cage)
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
                .Where(fs => fs.CageId.ToLower().Equals(cageId.ToLower().Trim()))
                .OrderByDescending(fs => fs.No)
                .ToListAsync();
        }

        public async Task<bool> Save()
        {
            var saved = _dbContext.SaveChangesAsync();
            return await saved > 0;
        }

        public async Task<bool> UpdateFeedingScheduleStatus(FeedingSchedule feedingSchedule)
        {
            // validation about feeding amount
            var existingFeedingSchedule = await GetFeedingSchedule(feedingSchedule.No);
            if (existingFeedingSchedule == null) return false;

            existingFeedingSchedule.FeedingStatus = feedingSchedule.FeedingStatus;
            _dbContext.FeedingSchedules.Update(existingFeedingSchedule);
            return await Save();
        }
    }
}
