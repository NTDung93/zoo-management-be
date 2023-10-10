﻿namespace API.Models.Dtos
{
    public class EmployeeResponse
    {
        public string EmployeeId { get; set; }
        public string FullName { get; set; }
        public string CitizenId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Image { get; set; }
        public byte EmployeeStatus { get; set; }
    }
}
