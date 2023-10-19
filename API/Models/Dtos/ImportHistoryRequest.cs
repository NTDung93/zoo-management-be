namespace API.Models.Dtos
{
    public class ImportHistoryRequest
    {
        public DateTime ImportDate { get; set; }
        public int ImportQuantity { get; set; }
        public string FoodId { get; set; }
    }
}
