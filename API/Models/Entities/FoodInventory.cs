namespace API.Models.Entities
{
    public class FoodInventory
    {
        public string FoodId { get; set; }
        public string FoodName { get; set; }
        public int InventoryQuantity { get; set; }
        public ICollection<ImportHistory> ImportHistories { get; set; }
        public ICollection<FeedingMenu> FeedingSchedules { get; set; }
    }
}
