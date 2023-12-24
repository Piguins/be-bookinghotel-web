using System.Text.Json;
using Domain.Common.ValueObjects;
using Infrastructure.Persistence.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.SeedData;

public static class SeedData
{
    private static string BasePath { get; } = "../Infrastructure/Persistence/SeedData/";


    public static Task Initialize(ApplicationDbContext context)
    {
        var userAsync = SeedUsers(context);
        var roomAsync = SeedRooms(context);

        return Task.WhenAll(userAsync, roomAsync);
    }

    public static async Task SeedUsers(ApplicationDbContext context)
    {
        if (await context.Users.AnyAsync().ConfigureAwait(false))
        {
            return;
        }

        string data = await File.ReadAllTextAsync(BasePath + "Users.json").ConfigureAwait(false);
        if (JsonSerializer.Deserialize<List<User>>(data) is not { } users)
        {
            throw new InvalidOperationException("Users not found");
        }

        foreach (var u in users)
        {
            var user = Domain.Users.User.Create(
                u.Email,
                u.FirstName,
                u.LastName,
                u.Password,
                id: u.Id);

            foreach (string roleName in u.Roles)
            {
                if (context.Roles.FirstOrDefault(x =>
                    x.Name == roleName) is not { } role)
                {
                    throw new InvalidOperationException("Role not found");
                }
                user.Roles.Add(role);
            }

            context.Add(user);
        }

        await context.SaveChangesAsync().ConfigureAwait(false);
    }

    public static async Task SeedRooms(ApplicationDbContext context)
    {
        if (await context.Rooms.AnyAsync().ConfigureAwait(false))
        {
            return;
        }

        string data = await File.ReadAllTextAsync(BasePath + "Rooms.json").ConfigureAwait(false);
        if (JsonSerializer.Deserialize<List<Room>>(data) is not { } rooms)
        {
            throw new InvalidOperationException("Users not found");
        }

        foreach (var u in rooms)
        {
            if (await context.Floors.FirstOrDefaultAsync(x =>
                x.Name == u.Floor) is not { } floor)
            {
                throw new InvalidOperationException("Floor not found");
            }
            if (Money.FromCurrency(u.Currency) is not { } price)
            {
                throw new InvalidOperationException("Currency found");
            }
            var user = Domain.Rooms.Room.Create(
                u.Name,
                u.Description,
                u.IsReserved,
                floor,
                u.BedCount,
                price,
                u.Images,
                id: u.Id);

            context.Add(user);
        }

        await context.SaveChangesAsync().ConfigureAwait(false);
    }
}
