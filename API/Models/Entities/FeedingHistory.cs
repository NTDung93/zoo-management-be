namespace API.Models.Entities
{
    public class FeedingHistory
    {
        public int HistoryNo { get; set; }
        public string ScheduleNo { get; set; }
        public DateTime FeedingTime { get; set; }
        public byte FeedingStatus { get; set; }
        public FeedingSchedule FeedingSchedule { get; set; }
    }
}
