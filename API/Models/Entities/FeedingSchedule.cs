namespace API.Models.Entities
{
    public class FeedingSchedule
    {
        public int No { get; set; }
        public string ScheduleNo { get; set; }
        public string CageId { get; set; }
        public string AnimalId { get; set; }
        public string EmployeeId { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double FeedingAmount { get; set; }
        public byte FeedingStatus { get; set; }
        public Animal Animal { get; set; }
        public Cage Cage { get; set; }  
        public FeedingMenu FeedingMenu { get; set; }
        public Employee Employee { get; set; }
    }
}
