using API.Models.Dtos;
using API.Models.Entities;

namespace API.Repositories
{
    public interface IFoodInventoryRepository
    {
        Task<IEnumerable<FoodInventory>> GetFoods();
        Task<FoodInventory> GetFood(string id);
        Task<IEnumerable<FoodInventory>> SearchFoodByName(string name);
        Task<bool> CreateFood(FoodInventory food);
        Task<bool> DeleteFood(string id);
        Task<bool> UpdateFood(FoodInventoryRequest food);
        Task<bool> FindFoodInScheduleMenu(string foodId);
        Task<bool> Save();
    }
}
