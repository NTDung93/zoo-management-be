namespace API.Models.Entities
{
    public class FeedingMenu
    {
        public string MenuNo { get; set; }
        public string MenuName { get; set; }
        public string FoodId { get; set; }
        public int SpeciesId { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public FoodInventory FoodInventory { get; set; }
        public AnimalSpecies AnimalSpecies { get; set; }
        public ICollection<FeedingSchedule> FeedingSchedules { get; set; }

    }
}
