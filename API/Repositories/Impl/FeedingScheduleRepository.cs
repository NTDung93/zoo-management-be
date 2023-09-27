using API.Models;
using API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Impl
{
    public class FeedingScheduleRepository : IFeedingScheduleRepository
    {
        private readonly ZooManagementContext _context;

        public FeedingScheduleRepository(ZooManagementContext context)
        {
            this._context = context;
        }

        public async Task CreateSchedule(FeedingSchedule feedingSchedule)
        {
            _context.FeedingSchedules.Add(feedingSchedule);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSchedule(int id)
        {
            var feedingSchedule = _context.FeedingSchedules.FindAsync(id);
            _context.FeedingSchedules.Remove(feedingSchedule.Result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<FeedingSchedule>> GetFeedingScheduleByAnimalName(string name)
        {
            var feedingSchedule = _context.FeedingSchedules.Include(x => x.Animal).Include(y => y.Employee).Include(z => z.Food).Where(a => a.Animal.Name.ToLower().Contains(name.Trim().ToLower())).ToListAsync();
            return await feedingSchedule;
        }

        public async Task<IEnumerable<FeedingSchedule>> GetFeedingScheduleByFood(string name)
        {
            var feedingSchedule = _context.FeedingSchedules.Include(x => x.Animal).Include(y => y.Employee).Include(z => z.Food).Where(a => a.Food.Name.ToLower().Contains(name.Trim().ToLower())).ToListAsync();
            return await feedingSchedule;
        }

        public async Task<FeedingSchedule> GetFeedingScheduleById(int id)
        {
            return await _context.FeedingSchedules.Include(x => x.Animal).Include(y => y.Employee).Include(z => z.Food).FirstOrDefaultAsync(schedule => schedule.ScheduleNo == id);
        }

        public async Task<IEnumerable<FeedingSchedule>> GetListFeedingSchedule()
        {
            return await _context.FeedingSchedules.Include(x => x.Animal).Include(y => y.Employee).Include(z => z.Food).OrderBy(a => a.ScheduleNo).ToListAsync();
        }

        public Task UpdateSchedule(int id, FeedingScheduleDto scheduleDto)
        {
            var feedingSchedule = GetFeedingScheduleById(id);
            feedingSchedule.Result.FeedTime = scheduleDto.FeedTime;
            feedingSchedule.Result.FoodId = scheduleDto.FoodId;
            feedingSchedule.Result.AnimalId = scheduleDto.AnimalId;
            feedingSchedule.Result.EmployeeId = scheduleDto.EmployeeId;
            feedingSchedule.Result.FeedStatus = scheduleDto.FeedStatus;
            return _context.SaveChangesAsync();
        }
    }
}
