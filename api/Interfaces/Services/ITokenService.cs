using System.Security.Claims;
using api.Models;

namespace api.Interfaces.Services
{
    public interface ITokenService
    {
        string CreateToken(User user);

        string GenerateRefreshToken();

        ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token);
    }
}