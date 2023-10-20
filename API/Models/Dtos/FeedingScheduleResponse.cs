﻿using API.Models.Entities;

namespace API.Models.Dtos
{
    public class FeedingScheduleResponse
    {
        public int No { get; set; }
        public string MenuNo { get; set; }
        public string CageId { get; set; }
        public string AnimalId { get; set; }
        public string EmployeeId { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double FeedingAmount { get; set; }
        public byte FeedingStatus { get; set; }
        public AnimalDto Animal { get; set; }
        public CageDto Cage { get; set; }
        public FeedingMenuResponse FeedingMenu { get; set; }
        public EmployeeResponse Employee { get; set; }
    }
}
