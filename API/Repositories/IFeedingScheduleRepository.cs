using API.Models.Entities;

namespace API.Repositories
{
    public interface IFeedingScheduleRepository
    {
        // add an interface to retrieve the next schedule
        Task<IEnumerable<FeedingSchedule>> GetFeedingSchedules();
        Task<FeedingSchedule> GetFeedingSchedule(int no);
        Task<IEnumerable<FeedingSchedule>> GetFeedingSchedulesByCage(string cageId);
        Task<IEnumerable<FeedingSchedule>> GetFeedingSchedulesByAnimal(string animalId);
        Task<bool> CreateFeedingSchedule(FeedingSchedule feedingSchedule);
        Task<bool> UpdateFeedingScheduleStatus(FeedingSchedule feedingSchedule);
        Task<bool> Save();
    }
}
