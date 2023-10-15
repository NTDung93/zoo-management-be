namespace API.Models.Entities
{
    public class FeedingMenu
    {
        public string ScheduleNo { get; set; }
        public string ScheduleName { get; set; }
        public string FoodId { get; set; }
        public int FeedingQuantity { get; set; }    
        public FoodInventory FoodInventory { get; set; }
        public ICollection<FeedingSchedule> FeedingSchedules { get; set; }

    }
}
