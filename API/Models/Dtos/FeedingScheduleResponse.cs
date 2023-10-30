using API.Models.Entities;
using Newtonsoft.Json;

namespace API.Models.Dtos
{
    public class FeedingScheduleResponse
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
        public AnimalDto Animal { get; set; }
        public CageDto Cage { get; set; }
        public FeedingMenuResponse FeedingMenu { get; set; }
        public EmployeeResponse Employee { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
