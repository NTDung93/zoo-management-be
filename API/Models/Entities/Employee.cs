using System;
using System.Collections.Generic;

namespace API.Models.Entities;

public partial class Employee
{
    public string Id { get; set; }

    public string FullName { get; set; }

    public string CitizenId { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public string PhoneNumber { get; set; }

    public string Image { get; set; }

    public string Role { get; set; }

    public byte? IsDeleted { get; set; }
    
    public string RefreshToken { get; set; }
    
    public DateTime? RefreshTokenExpiryTime { get; set; }

    public virtual ICollection<Animal> Animals { get; set; } = new List<Animal>();

    public virtual ICollection<EmployeeCertificate> EmployeeCertificates { get; set; } = new List<EmployeeCertificate>();

    public virtual ICollection<FeedingSchedule> FeedingSchedules { get; set; } = new List<FeedingSchedule>();

    public virtual ICollection<News> News { get; set; } = new List<News>();
}
