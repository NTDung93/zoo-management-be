namespace API.Models.Dtos
{
    public class ImportHistoryResponse
    {
        public int No { get; set; }
        public DateTime ImportDate { get; set; }
        public int ImportQuantity { get; set; }
        public string FoodId { get; set; }
        public FoodInventoryResponse FoodInventory { get; set; }
    }
}
