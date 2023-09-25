using API.Models.Entities;

namespace API.Repositories
{
    public interface IFeedingScheduleRepository
    {
        Task<IEnumerable<FeedingSchedule>> GetListFeedingSchedule();
        Task<FeedingSchedule> GetFeedingScheduleById(int id);
        Task DeleteSchedule(int id);
        Task<IEnumerable<FeedingSchedule>> GetFeedingScheduleByAnimalName(string name);
        Task<IEnumerable<FeedingSchedule>> GetFeedingScheduleByFood(string name);
        Task CreateSchedule(FeedingSchedule feedingSchedule);
        Task UpdateSchedule(int id, FeedingScheduleDto scheduleDto);
    }
}
