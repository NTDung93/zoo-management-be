namespace API.Models.Entities
{
    public class FeedingSchedule
    {
        public string ScheduleNo { get; set; }
        public int ScheduleName { get; set; }
        public string FoodId { get; set; }
        public FoodInventory FoodInventory { get; set; }
        public ICollection<FeedingHistory> FeedingHistories { get; set; }
        public ICollection<Animal> Animals { get; set; }
        public ICollection<Cage> Cages { get; set; }


    }
}
