using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Services.Authentication;
using Application.Authentication;
using Application.Abstractions.Commons;
using Infrastructure.Services.Commons;
using Application.Abstractions.Persistence;
using Infrastructure.Services.Repositories;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        // string? connectionString = configuration.GetConnectionString("DefaultConnection");
        // services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
        services.AddCommon();
        services.AddPersistence();
        services.AddAuthentication(configuration);

        return services;
    }

    private static IServiceCollection AddCommon(this IServiceCollection services)
    {
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        return services;
    }

    private static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        return services;
    }

    private static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}
