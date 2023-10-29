namespace API.Models.Entities
{
    public class News
    {
        public int NewsId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime? WritingDate { get; set; }
        public string Image { get; set; }
        public string EmployeeId { get; set; }
        public int SpeciesId { get; set; }
        public string AnimalId { get; set; }
        public Animal Animal { get; set; }
        public Employee Employee { get; set; }
        public AnimalSpecies AnimalSpecies { get; set; }
    }
}
