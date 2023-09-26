namespace API.Models.Authen
{
    public class AuthenticatedResponse
    {
        public AdminAuthen Admin { get; set; }
        public EmpProfileModel Employee { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
