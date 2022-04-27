using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Core.Domain.Entities;
using Core.Services;
using Microsoft.IdentityModel.Tokens;

namespace WebApi.Services;

public class TokenService : ITokenService
{
    public static byte[] GetKey()
    {
        var secret = Environment.GetEnvironmentVariable("JWT_SECURITY");

        if (string.IsNullOrEmpty(secret))
        {
            secret = "NotASecurePassword";
        }

        return Encoding.ASCII.GetBytes(secret);
    }
    public string GenerateToken(Customer customerDb)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Email, customerDb.Email),
                new Claim(ClaimTypes.Role, customerDb.Role),
                new Claim(ClaimTypes.Name, customerDb.Name),
                new Claim(ClaimTypes.Surname, customerDb.SurName),
                new Claim("Id", customerDb.Id.ToString()),
            }),
            Expires = DateTime.UtcNow.AddMinutes(10),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(GetKey()), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}