using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

using RemoteConfig.Core.Exceptions;
using RemoteConfig.DataAccess.Identity;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RemoteConfig.Application.Helpers
{
    public static class JwtHelper
    {
        public static string GenerateToken(ApplicationUser user, IConfiguration configuration)
        {
            var secretKey = configuration.GetValue<string>("JwtConfiguration:SecretKey");

            if (string.IsNullOrEmpty(secretKey))
            {
                throw new NotFoundException("Secret key not found in configuration.");
            }

            var key = Encoding.ASCII.GetBytes(secretKey);

            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                [
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, user.Role)
                ]),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials =
                    new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}