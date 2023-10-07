using System.Security.Claims;

namespace API.Helpers.Token
{
    public interface ITokenHelper
    {
        string GenerateAccessToken(IEnumerable<Claim> claims);
        string GenerateAccessToken_V2(IEnumerable<Claim> claims);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
