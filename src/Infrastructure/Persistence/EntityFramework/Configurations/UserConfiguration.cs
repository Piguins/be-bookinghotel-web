// using Domain.Guest;
// using Domain.Host;
// using Domain.User;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata.Builders;
//
// namespace Infrastructure.Persistence.Configurations;
//
// public class UserConfiguration : IEntityTypeConfiguration<User>
// {
//     public void Configure(EntityTypeBuilder<User> builder)
//     {
//         ConfigureUser(builder);
//         ConfigurePerson(builder);
//     }
//
//     private static void ConfigurePerson(EntityTypeBuilder<User> builder) =>
//         builder.OwnsOne(u => u.Person, b =>
//         {
//             b.ToTable("Persons");
//             b.HasKey(p => p.Id);
//
//             b.Property(p => p.Id)
//                 .ValueGeneratedNever()
//                 .HasConversion(id => id.Value, value => new(value));
//         });
//
//     private static void ConfigureUser(EntityTypeBuilder<User> builder)
//     {
//         builder.ToTable("Users");
//         builder.HasKey(u => u.Id);
//
//         builder
//             .Property(u => u.Id)
//             .ValueGeneratedNever()
//             .HasConversion(id => id.Value, value => new(value));
//
//         builder.HasOne<Host>()
//             .WithMany()
//             .HasForeignKey(u => u.HostId);
//         builder
//             .Property(u => u.HostId)
//             .ValueGeneratedNever()
//             .HasConversion(id => id.Value, value => new(value));
//
//         builder.HasOne<Guest>()
//             .WithMany()
//             .HasForeignKey(u => u.GuestId);
//         builder
//             .Property(u => u.GuestId)
//             .ValueGeneratedNever()
//             .HasConversion(id => id.Value, value => new(value));
//
//     }
// }
