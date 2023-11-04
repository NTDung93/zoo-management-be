using API.Models.Entities;

namespace API.Models.Dtos
{
    public class FeedingMenuResponse
    {
        public string MenuNo { get; set; }
        public string MenuName { get; set; }
        public string FoodId { get; set; }
        public int SpeciesId { get; set; }
        public FoodInventoryResponse FoodInventory { get; set; }
        public AnimalSpeciesResponse AnimalSpecies { get; set; }
    }
}
