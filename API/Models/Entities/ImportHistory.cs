namespace API.Models.Entities
{
    public class ImportHistory
    {
        public int No { get; set; }
        public DateTime ImportDate { get; set; }
        public int ImportQuantity { get; set; }
        public string FoodId { get; set; }
        public FoodInventory FoodInventory { get; set; }
    }
}
