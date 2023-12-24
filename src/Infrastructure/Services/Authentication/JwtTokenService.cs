using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Abstractions.Commons;
using Application.Users.Auth;
using Domain.Users;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Services.Authentication;

public sealed class JwtTokenService(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> jwtOptions) : IJwtTokenService
{
    private readonly SymmetricSecurityKey _key = new(Encoding.UTF8.GetBytes(jwtOptions.Value.SecretKey));

    public string GenerateToken(User user)
    {
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.Id.Value.ToString()),
            new(JwtRegisteredClaimNames.GivenName, user.FirstName),
            new(JwtRegisteredClaimNames.FamilyName, user.LastName),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        var token = new JwtSecurityToken(
            issuer: jwtOptions.Value.Issuer,
            audience: jwtOptions.Value.Audience,
            expires: dateTimeProvider.UtcNow.AddMinutes(jwtOptions.Value.ExpireMinutes),
            signingCredentials: new SigningCredentials(_key, SecurityAlgorithms.HmacSha256),
            claims: claims);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

}
