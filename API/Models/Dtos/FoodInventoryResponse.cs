namespace API.Models.Dtos
{
    public class FoodInventoryResponse
    {
        public string FoodId { get; set; }
        public string FoodName { get; set; }
        public int InventoryQuantity { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
    }
}
