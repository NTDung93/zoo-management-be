using Newtonsoft.Json;

namespace API.Models.Dtos
{
    public class FeedingScheduleRequest
    {
        public int No { get; set; }
        public string MenuNo { get; set; }
        public string CageId { get; set; }
        public string AnimalId { get; set; }
        public string EmployeeId { get; set; }
        public DateTimeOffset CreatedTime { get; set; }
        [JsonProperty(PropertyName = "StartTime")]
        public DateTimeOffset StartTime { get; set; }
        [JsonProperty(PropertyName = "EndTime")]
        public DateTimeOffset EndTime { get; set; }
        public double FeedingAmount { get; set; }
        public byte FeedingStatus { get; set; }
        public string Note { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
