using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using api.Interfaces;
using api.Models;
using Microsoft.IdentityModel.Tokens;

namespace api.Service
{
    public class TokenService : ITokenService
    {
        private IConfiguration configuration;

        private SymmetricSecurityKey key;
        public TokenService(IConfiguration configuration)
        {
            this.configuration = configuration;
            key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SigningKey"]));
        }
        public string CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email/*JwtRegisteredClaimNames.Email*/, user.Email),
                new Claim(ClaimTypes.Name/*JwtRegisteredClaimNames.GivenName*/, user.UserName)
            };

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
               Subject = new ClaimsIdentity(claims),
               Expires = DateTime.Now.AddHours(2),
               SigningCredentials = credentials,
               Issuer = configuration["JWT:Issuer"],
               Audience = configuration["JWT:Audience"] 
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public string GenerateRefreshToken()
        {
            var randNumber = new byte[64];

            using var generator = RandomNumberGenerator.Create();

            generator.GetBytes(randNumber);

            return Convert.ToBase64String(randNumber);
        }

        public ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token)
        {
            var validation = new TokenValidationParameters{
                ValidateIssuer = true,
                ValidIssuer = configuration["JWT:Issuer"],
                ValidateAudience = true,
                ValidAudience = configuration["JWT:Audience"],
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(configuration["JWT:SigningKey"])
                )
            };

            var handler = new JwtSecurityTokenHandler().ValidateToken(token, validation, out _);
            return handler;
        }
    }
}