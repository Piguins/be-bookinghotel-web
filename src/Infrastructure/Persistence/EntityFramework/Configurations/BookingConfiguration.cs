// using Domain.Booking;
// using Domain.Booking.Enums;
// using Domain.Guest;
// using Domain.RoomType;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata.Builders;
//
// namespace Infrastructure.Persistence.Configurations;
//
// public class BookingConfiguration : IEntityTypeConfiguration<Booking>
// {
//     public void Configure(EntityTypeBuilder<Booking> builder) => ConfigureBooking(builder);
//
//     private static void ConfigureBooking(EntityTypeBuilder<Booking> builder)
//     {
//         builder.ToTable("Bookings");
//         builder.HasKey(b => b.Id);
//
//         builder.Property(b => b.Id)
//             .ValueGeneratedNever()
//             .HasConversion(
//                     id => id.Value,
//                     value => new(value));
//
//         builder.HasOne<Guest>()
//             .WithMany()
//             .HasForeignKey(b => b.GuestId);
//         builder.Property(b => b.GuestId)
//             .ValueGeneratedNever()
//             .HasConversion(
//                     id => id.Value,
//                     value => new(value));
//
//         builder.HasOne<RoomType>()
//             .WithMany()
//             .HasForeignKey(b => b.RoomTypeId);
//         builder.Property(b => b.RoomTypeId)
//             .ValueGeneratedNever()
//             .HasConversion(
//                     id => id.Value,
//                     value => new(value));
//
//         builder.Property(b => b.BookingStatus)
//             .HasConversion(
//                 status => status.Name,
//                 name => BookingStatus.FromName(name)!);
//
//     }
// }
//
