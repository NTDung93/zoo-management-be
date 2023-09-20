using System;
using System.Collections.Generic;

namespace API.Models.Entities;

public partial class Animal
{
    public string Id { get; set; }

    public string Name { get; set; }

    public string Region { get; set; }

    public string Behavior { get; set; }

    public string Gender { get; set; }

    public DateTime? BirthDate { get; set; }

    public string Image { get; set; }

    public byte? HealthStatus { get; set; }

    public string Rarity { get; set; }

    public byte? IsDeleted { get; set; }

    public string EmpId { get; set; }

    public string CageId { get; set; }

    public virtual Cage Cage { get; set; }

    public virtual Employee Emp { get; set; }

    public virtual ICollection<FeedingSchedule> FeedingSchedules { get; set; } = new List<FeedingSchedule>();

    public virtual ICollection<News> News { get; set; } = new List<News>();
}
