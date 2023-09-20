namespace API.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public string ProductCode { get; set; }

        public decimal? Price { get; set; }

        public DateTime? DateCreate { get; set; }
        public int CategoryId { get; set; }
    }
}
