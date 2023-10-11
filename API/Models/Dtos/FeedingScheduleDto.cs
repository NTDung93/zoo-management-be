using API.Models.Dtos;
using API.Models.Entities;
using System;

public class FeedingScheduleDto
{
    public int ScheduleNo { get; set; }
    public DateTime FeedTime { get; set; }
    public int FeedQuantity { get; set; }
    public byte FeedStatus { get; set; }
    public int FoodId { get; set; }
    public string EmployeeId { get; set; }
    public string AnimalId { get; set; }
    public EmployeeResponse Employee { get; set; }
    public AnimalDto Animal { get; set; }
    public FoodDto Food { get; set; }
}   