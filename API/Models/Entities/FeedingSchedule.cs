namespace API.Models.Entities
{
    public class FeedingSchedule
    {
        public int No { get; set; }
        public string ScheduleNo { get; set; }
        public string CageId { get; set; }
        public string AnimalId { get; set; }
        public DateTime FeedingTime { get; set; }
        public double FeedingAmount { get; set; }
        public byte FeedingStatus { get; set; }
        public Animal Animal { get; set; }
        public Cage Cage { get; set; }  
        public FeedingMenu FeedingMenu { get; set; }        
    }
}
