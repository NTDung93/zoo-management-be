using Microsoft.Build.Framework;

namespace API.Models.Login
{
    // use this class in LoginController action method for authentication
    public class AccountLogin
    {
        public string Email { get; set; }

        public string Password { get; set; }

    }
}
