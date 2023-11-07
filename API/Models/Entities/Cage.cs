namespace API.Models.Entities
{
    public class Cage
    {
        public string CageId { get; set; }
        public string Name { get; set; }
        public int MaxCapacity { get; set; }
        public int CurrentCapacity { get; set; }
        public string AreaId { get; set; }
        public DateTimeOffset CreatedDate { get; set;}
        public Area Area { get; set; }
        public ICollection<Animal> Animals { get; set; }
        public ICollection<FeedingSchedule> FeedingSchedules { get; set; }
    }
}
