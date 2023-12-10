using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Services.Authentication.Setup;

public class JwtBearerOptionsSetup(IOptions<JwtSettings> jwtOptions, ILogger<JwtBearerOptionsSetup> logger)
    : IPostConfigureOptions<JwtBearerOptions>
{
    public void PostConfigure(string? name, JwtBearerOptions options)
    {
        logger.LogInformation("{name} is called. Policy name: {policyName}", nameof(JwtBearerOptionsSetup), name);

        options.TokenValidationParameters = new()
        {
            ValidateLifetime = true,
            ValidAudience = jwtOptions.Value.Audience,
            ValidateAudience = true,
            ValidIssuer = jwtOptions.Value.Issuer,
            ValidateIssuer = true,
            IssuerSigningKey =
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Value.SecretKey)),
            ValidateIssuerSigningKey = true,
        };
    }

}
