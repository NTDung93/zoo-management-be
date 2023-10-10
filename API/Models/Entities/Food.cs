namespace API.Models.Entities
{
    public class Food
    {
        public int FoodId { get; set; }
        public string FoodName { get; set; }
        public int Quantity { get; set; }
        public ICollection<ImportHistory> ImportHistories { get; set; }
        public ICollection<FeedingSchedule> FeedingSchedules { get; set; }
    }
}
