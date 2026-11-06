using System.Security.Claims;
using System.Text;
using DalilAcademy.Core.DTOs;
using DalilAcademy.Core.Entities;
using DalilAcademy.Core.Security;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace DalilAcademy.Infra;

public class TokenService(IOptions<JwtSettings> options) : ITokenService
{
   public  LoginResponseDto CreateToken(User user)
    {
        var jwt = options.Value;
        var expiresAt = DateTime.UtcNow.AddHours(jwt.ExpiresInHours);
        var descriptor = new SecurityTokenDescriptor
        {
            Issuer = jwt.Issuer,
            Audience = jwt.Audience,
            Expires = expiresAt,
            Subject = new ClaimsIdentity([
            new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
            new Claim(ClaimTypes.Email,user.Email),
            new Claim(ClaimTypes.Role,user.Role)
            ]),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key)),
                SecurityAlgorithms.HmacSha256)
            
        };
        return new LoginResponseDto(new JsonWebTokenHandler().CreateToken(descriptor), expiresAt);
    }

}