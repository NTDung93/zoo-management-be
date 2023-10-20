using API.Models.Dtos;
using API.Models.Entities;

namespace API.Repositories
{
    public interface IFeedingMenuRepository
    {
        Task<IEnumerable<FeedingMenu>> GetFeedingMenus();
        Task<FeedingMenu> GetFeedingMenu(string scheduleNo);
        Task<bool> CreateFeedingMenu(FeedingMenu feedingMenu);
        Task<bool> UpdateFeedingMenu(FeedingMenuRequest feedingMenu);
        Task<bool> DeleteFeedingMenu(string scheduleNo);
        Task<bool> Save();
    }
}
