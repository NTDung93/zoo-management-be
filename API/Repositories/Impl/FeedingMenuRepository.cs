﻿using API.Models.Data;
using API.Models.Dtos;
using API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Impl
{
    public class FeedingMenuRepository : IFeedingMenuRepository
    {
        private readonly ZooManagementBackupContext _dbContext;

        public FeedingMenuRepository(ZooManagementBackupContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CreateFeedingMenu(FeedingMenu feedingMenu)
        {
            await _dbContext.FeedingMenus.AddAsync(feedingMenu);
            return await Save();
        }

        public async Task<bool> DeleteFeedingMenu(string scheduleNo)
        {
            var feedingMenu = await GetFeedingMenu(scheduleNo);
            if (feedingMenu == null) return false;

            var isExisted = await _dbContext.FeedingSchedules
                .AnyAsync(fs => fs.ScheduleNo.Equals(feedingMenu.ScheduleNo));
            if (isExisted) return false;

            _dbContext.FeedingMenus.Remove(feedingMenu);
            return await Save();
        }

        public async Task<FeedingMenu> GetFeedingMenu(string scheduleNo)
        {
            return await _dbContext.FeedingMenus
                .Include(fm => fm.FoodInventory)
                .FirstOrDefaultAsync(fm => fm.ScheduleNo.ToLower().Trim().Equals(scheduleNo.Trim().ToLower()));
        }

        public async Task<IEnumerable<FeedingMenu>> GetFeedingMenus()
        {
            return await _dbContext.FeedingMenus
                .Include(fm => fm.FoodInventory)
                .OrderByDescending(fm => fm.ScheduleNo)
                .ToListAsync();
        }

        public async Task<bool> Save()
        {
            var saved = _dbContext.SaveChangesAsync();
            return await saved > 0;
        }

        public async Task<bool> UpdateFeedingMenu(FeedingMenuRequest feedingMenu)
        {
            var existingFeedingMenu = await GetFeedingMenu(feedingMenu.ScheduleNo);
            if (existingFeedingMenu == null) return false;

            existingFeedingMenu.ScheduleName = feedingMenu.ScheduleName;
            existingFeedingMenu.FoodId = feedingMenu.FoodId;
            
            _dbContext.FeedingMenus.Update(existingFeedingMenu);
            return await Save();
        }
    }
}