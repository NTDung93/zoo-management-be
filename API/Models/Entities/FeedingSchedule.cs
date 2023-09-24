using System;
using System.Collections.Generic;

namespace API.Models.Entities;

public partial class FeedingSchedule
{
    public int ScheduleNo { get; set; }

    public int FoodId { get; set; }

    public string EmployeeId { get; set; }

    public string AnimalId { get; set; }

    public DateTime? FeedTime { get; set; }

    public byte? FeedStatus { get; set; }

    public virtual Animal Animal { get; set; }

    public virtual Employee Employee { get; set; }

    public virtual Food Food { get; set; }
}
