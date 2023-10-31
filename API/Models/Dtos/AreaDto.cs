using API.Models.Entities;

namespace API.Models.Dtos
{
    public class AreaDto
    {
        public string AreaId { get; set; }
        public string AreaName { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public string EmployeeId { get; set; }
        public EmployeeDto Employee { get; set; }
    }
}
