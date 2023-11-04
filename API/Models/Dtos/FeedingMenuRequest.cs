using API.Models.Entities;

namespace API.Models.Dtos
{
    public class FeedingMenuRequest
    {
        public string MenuNo { get; set; }
        public string MenuName { get; set; }
        public string FoodId { get; set; }
        public int SpeciesId { get; set; }
    }
}
