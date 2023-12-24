using Application.Abstractions.Persistence;
using Domain.Bookings;
using Domain.Common.Enums;
using Domain.Rooms;
using Domain.Rooms.Entities;
using Domain.Users;
using Domain.Users.Enums;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.EntityFramework;

public class ApplicationDbContext(DbContextOptions options) : DbContext(options), IUnitOfWork
{
    public DbSet<Floor> Floors { get; set; } = null!;

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Role> Roles { get; set; } = null!;

    public DbSet<Room> Rooms { get; set; } = null!;
    public DbSet<RoomImage> RoomImages { get; set; } = null!;

    public DbSet<Booking> Bookings { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(InfrastructureAssembly.Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
