using API.Models.Entities;

namespace API.Models.Dtos
{
    public class FeedingMenuResponse
    {
        public string ScheduleNo { get; set; }
        public string ScheduleName { get; set; }
        public string FoodId { get; set; }
        public FoodInventoryResponse FoodInventory { get; set; }
    }
}
