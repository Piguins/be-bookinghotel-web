using Infrastructure.Services.Authentication;
using Infrastructure.Services.Authentication.Setup;
using Application.Abstractions.Commons;
using Application.Bookings;
using Application.Rooms;
using Infrastructure.Persistence.EntityFramework;
using Infrastructure.Services.Commons;
using Infrastructure.Persistence.Repositories;
using Application.Users.Auth;
using Application.Users;
using Infrastructure.Services.Authorization;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.EntityFrameworkCore;
using Application.Abstractions.Persistence;
using Microsoft.AspNetCore.Builder;
using Infrastructure.Persistence.SeedData;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services
            .AddServices(configuration)
            .AddPersistence(configuration);

        return services;
    }

    private static IServiceCollection AddPersistence(this IServiceCollection services, ConfigurationManager configuration)
    {
        string? connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlite(connectionString);
            // options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        });

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IBookingRepository, BookingRepository>();
        services.AddScoped<IRoomRepository, RoomRepository>();
        return services;
    }

    private static IServiceCollection
        AddServices(this IServiceCollection services, ConfigurationManager configuration) => services
        .AddCommon()
        .AddAuth(configuration);

    private static IServiceCollection AddCommon(this IServiceCollection services)
    {
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        return services;
    }

    private static IServiceCollection AddAuth(this IServiceCollection services, ConfigurationManager configuration)
    {
        services
            .ConfigureOptions<JwtSettingsSetup>()
            .ConfigureOptions<JwtBearerOptionsSetup>()
            .AddSingleton<IJwtTokenService, JwtTokenService>();

        JsonWebTokenHandler.DefaultInboundClaimTypeMap.Clear();
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer();

        services.AddSingleton<IAuthorizationHandler, PermissionAuthorizationHandler>();
        services.AddSingleton<IAuthorizationPolicyProvider, PermissionAuthorizationPolicyProvider>();

        return services;
    }

    public static async Task<WebApplication> UseSeedDataAsync(this WebApplication app)
    {
        ArgumentNullException.ThrowIfNull(app, nameof(app));
        using var scope = app.Services.CreateScope();
        var service = scope.ServiceProvider;

        var context = service.GetRequiredService<ApplicationDbContext>();
        await context.Database.MigrateAsync().ConfigureAwait(false);
        await SeedData.Initialize(context).ConfigureAwait(false);

        return app;
    }
}
