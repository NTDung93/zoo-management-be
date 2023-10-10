namespace API.Models.Entities
{
    public class ImportHistory
    {
        public int No { get; set; }
        public DateTime ImportDate { get; set; }
        public int ImportQuantity { get; set; }
        public int FoodId { get; set; }
        public Food Food { get; set; }
    }
}
