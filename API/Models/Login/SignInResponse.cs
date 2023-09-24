using API.Models.Dtos;

namespace API.Models.Login
{
    public class SignInResponse
    {
        public AdminAccount AdminAccount { get; set; }
        public EmployeeDto Employee { get; set; }
        public string AccessToken { get; set; }
    }
}
