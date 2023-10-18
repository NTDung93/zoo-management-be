namespace API.Models.Dtos
{
    public class FeedingScheduleRequest
    {
        public int No { get; set; }
        public string ScheduleNo { get; set; }
        public string CageId { get; set; }
        public string AnimalId { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double FeedingAmount { get; set; }
        public byte FeedingStatus { get; set; }
    }
}
