namespace API.Models.Dtos
{
    public class TicketDto
    {
        public int TicketId { get; set; }
        public string Type { get; set; }
        public decimal? UnitPrice { get; set; }
    }
}
