namespace API.Models.Entities
{
    public class FeedingSchedule
    {
        public int ScheduleNo { get; set; }
        public DateTime FeedTime { get; set; }
        public int FeedQuantity { get; set; }
        public byte FeedStatus { get; set; }
        public int FoodId { get; set; }
        public string EmployeeId { get; set; }
        public string AnimalId { get; set; }    
        public Employee Employee { get; set; }
        public Animal Animal { get; set; }
        public Food Food { get; set; }
    }
}
