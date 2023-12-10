using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Infrastructure.Services.Authentication.Setup;

public class JwtSettingsSetup(IConfiguration configuration)
    : IConfigureOptions<JwtSettings>
{
    public void Configure(JwtSettings options)
    {
        configuration.Bind(JwtSettings.SectionName, options);
    }
}
