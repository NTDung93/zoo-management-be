namespace API.Models.Entities
{
    public class FeedingMenu
    {
        public string MenuNo { get; set; }
        public string MenuName { get; set; }
        public string FoodId { get; set; }    
        public FoodInventory FoodInventory { get; set; }
        public ICollection<FeedingSchedule> FeedingSchedules { get; set; }

    }
}
