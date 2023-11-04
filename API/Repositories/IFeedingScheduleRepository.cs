using API.Models.Entities;

namespace API.Repositories
{
    public interface IFeedingScheduleRepository
    {
        Task<IEnumerable<FeedingSchedule>> GetFeedingSchedules();
        Task<FeedingSchedule> GetFeedingSchedule(int no);
        Task<IEnumerable<FeedingSchedule>> GetFeedingSchedulesByCage(string cageId);
        Task<IEnumerable<FeedingSchedule>> GetFeedingSchedulesByAnimal(string animalId);
        Task<bool> CreateFeedingSchedule(FeedingSchedule feedingSchedule);
        Task<bool> UpdateFeedingScheduleStatus(FeedingSchedule feedingSchedule);
        Task<double> GetMaxFeedingQuantityOnAnimal(string animalId);
        Task<double> GetMaxFeedingQuantityOnCage(string cageId);
        Task<IEnumerable<FeedingSchedule>> GetFeedingScheduleOfATrainer(string trainerId);
        Task<IEnumerable<FeedingSchedule>> GetFeedingScheduleOfAnArea(string areaId);
        Task<bool> DeleteFeedingSchedule(int no);
        Task<bool> UpdateFeedingSchedule(FeedingSchedule feedingSchedule);
        Task<bool> Save();
    }
}
