using API.Models.Entities;

namespace API.Models.Dtos
{
    public class FeedingMenuRequest
    {
        public string ScheduleNo { get; set; }
        public string ScheduleName { get; set; }
        public string FoodId { get; set; }
    }
}
