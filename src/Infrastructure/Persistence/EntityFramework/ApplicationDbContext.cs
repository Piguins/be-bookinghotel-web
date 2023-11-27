// using Domain.Booking;
// using Domain.Guest;
// using Domain.Host;
// using Domain.Room;
// using Domain.RoomType;
// using Domain.User;
// using Microsoft.EntityFrameworkCore;
//
// namespace Infrastructure.Persistence;
//
// public class ApplicationDbContext : DbContext
// {
//     public ApplicationDbContext(DbContextOptions options)
//         : base(options) { }
//
//     public DbSet<Room> Rooms { get; set; } = null!;
//     public DbSet<RoomType> RoomTypes { get; set; } = null!;
//
//     public DbSet<Booking> Bookings { get; set; } = null!;
//
//     public DbSet<User> Users { get; set; } = null!;
//     public DbSet<Host> Hosts { get; set; } = null!;
//     public DbSet<Guest> Guests { get; set; } = null!;
//
//     protected override void OnModelCreating(ModelBuilder modelBuilder)
//     {
//         modelBuilder.ApplyConfigurationsFromAssembly(InfrastructureAssembly.Assembly);
//         base.OnModelCreating(modelBuilder);
//     }
// }
