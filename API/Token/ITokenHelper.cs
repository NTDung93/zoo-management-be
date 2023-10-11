using System.Security.Claims;

namespace API.Token
{
    public interface ITokenHelper
    {
        string GenerateAccessToken(IEnumerable<Claim> claims);
    }
}
