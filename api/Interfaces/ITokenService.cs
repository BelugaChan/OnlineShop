using System.Security.Claims;
using api.Models;

namespace api.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);

        string GenerateRefreshToken();

        ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token);
    }
}