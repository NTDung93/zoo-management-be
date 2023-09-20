using System;
using System.Collections.Generic;

namespace API.Models.Entities;

public partial class Food
{
    public int Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<FeedingSchedule> FeedingSchedules { get; set; } = new List<FeedingSchedule>();

    public virtual ICollection<ImportHistory> ImportHistories { get; set; } = new List<ImportHistory>();
}
