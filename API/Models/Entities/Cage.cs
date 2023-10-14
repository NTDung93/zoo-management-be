﻿namespace API.Models.Entities
{
    public class Cage
    {
        public string CageId { get; set; }
        public string Name { get; set; }
        public int MaxCapacity { get; set; }
        public int CurrentQuantity { get; set; }
        public string AreaId { get; set; }
        public string ScheduleNo { get; set; }
        public Area Area { get; set; }
        public FeedingSchedule FeedingSchedule { get; set; }
        public ICollection<Animal> Animals { get; set; }
    }
}
