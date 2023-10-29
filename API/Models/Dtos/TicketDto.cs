namespace API.Models.Dtos
{
    public class TicketDto
    {
        public string TicketId { get; set; }
        public string Type { get; set; }
        public decimal? UnitPrice { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
