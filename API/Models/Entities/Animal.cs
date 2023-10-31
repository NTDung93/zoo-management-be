namespace API.Models.Entities
{
    public class Animal
    {
        public string AnimalId { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
        public string Behavior { get; set; }
        public string Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? ImportDate { get; set; }
        public string Image { get; set; }
        public byte? HealthStatus { get; set; }
        public string Rarity { get; set; }
        public double MaxFeedingQuantity { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public byte? IsDeleted { get; set; }
        public string EmployeeId { get; set; }
        public string CageId { get; set; }
        public int SpeciesId { get; set; }
        public Employee Employee { get; set; }
        public AnimalSpecies AnimalSpecies { get; set; }
        public Cage Cage { get; set; }  
        public ICollection<News> News { get; set; } 
        public ICollection<FeedingSchedule> FeedingSchedules { get; set; }
    }
}
