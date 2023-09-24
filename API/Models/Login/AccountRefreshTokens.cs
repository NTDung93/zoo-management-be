namespace API.Models.Login
{
    public class AccountRefreshTokens
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string RefreshToken { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
