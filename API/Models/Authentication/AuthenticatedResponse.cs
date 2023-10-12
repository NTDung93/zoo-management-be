﻿namespace API.Models.Authentication
{
    public class AuthenticatedResponse
    {
        public string FullName { get; set; }
        public string CitizenId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Image { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }   
    }
}
