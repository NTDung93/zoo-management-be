using API.Models.Dtos;
using System.Diagnostics.CodeAnalysis;

namespace API.Models.Authentication
{
    public class AuthenticatedResponse
    {
        public string EmployeeId { get; set; }
        public string FullName { get; set; }
        public string CitizenId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Image { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
        public string AreaId { get; set; }
    }
}
