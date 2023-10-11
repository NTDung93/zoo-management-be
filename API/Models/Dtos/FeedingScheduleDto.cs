using API.Models.Dtos;
using API.Models.Entities;
using System;

public class FeedingScheduleDto
{
    public int ScheduleNo { get; set; }

    public int FoodId { get; set; }

    public string EmployeeId { get; set; }

    public string AnimalId { get; set; }

    public DateTime FeedTime { get; set; }

    public byte FeedStatus { get; set; }

    public virtual AnimalDto Animal { get; set; }

    public virtual EmployeeDto Employee { get; set; }

    public virtual FoodDto Food { get; set; }
}   