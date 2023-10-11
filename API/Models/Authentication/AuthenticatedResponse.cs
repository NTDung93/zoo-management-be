namespace API.Models.Authentication
{
    public class AuthenticatedResponse
    {
        public AdminModel Admin { get; set; }
        public EmployeeModel Employee { get; set; }
        public string Token { get; set; }   
    }
}
