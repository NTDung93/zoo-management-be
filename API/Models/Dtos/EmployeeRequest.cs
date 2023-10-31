namespace API.Models.Dtos
{
    public class EmployeeRequest
    {
        public string EmployeeId { get; set; }
        public string FullName { get; set; }
        public string CitizenId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Image { get; set; }
        public DateTimeOffset CreatedDate { get; set; }

    }
}
