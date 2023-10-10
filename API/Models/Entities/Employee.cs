namespace API.Models.Entities
{
    public class Employee
    {
        public string EmployeeId { get; set; }
        public string FullName { get; set; }
        public string CitizenId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Image { get; set; }
        public string Role { get; set; }
        public byte EmployeeStatus { get; set; }
        public string RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
        public ICollection<News> News { get; set; }
        public ICollection<EmployeeCertificate> EmployeeCertificates { get; set; }
        public ICollection<Animal> Animals { get; set; }
        public ICollection<FeedingSchedule> FeedingSchedules { get; set; }

    }
}
