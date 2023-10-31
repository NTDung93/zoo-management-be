namespace API.Models.Entities
{
    public class Area
    {
        public string AreaId { get; set; }
        public string AreaName { get; set; }
        public string EmployeeId { get; set; }
        public DateTimeOffset CreatedDate { get; set; } 
        public ICollection<Cage> Cages { get; set; }
        public Employee Employee { get; set; }
    }
}
