namespace API.Models.Entities
{
    public class AnimalSpecies
    {
        public int SpeciesId { get; set; }
        public string SpeciesName { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public ICollection<News> News { get; set; }
        public ICollection<Animal> Animals { get; set; }
        public ICollection<FeedingMenu> FeedingMenus { get; set; }
    }
}
