// using Domain.Guest;
// using Domain.Room;
// using Domain.Room.Enums;
// using Domain.RoomType;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata.Builders;
//
// namespace Infrastructure.Persistence.Configurations;
//
// public class RoomConfiguration : IEntityTypeConfiguration<Room>
// {
//     public void Configure(EntityTypeBuilder<Room> builder)
//     {
//         ConfigureRoom(builder);
//         ConfigureRoomRatings(builder);
//     }
//
//     private static void ConfigureRoomRatings(EntityTypeBuilder<Room> builder)
//     {
//         builder.OwnsMany(
//             r => r.RoomRatings,
//             b =>
//             {
//                 b.ToTable("RoomRatings");
//                 b.HasKey("Id", "RoomId");
//
//                 b.Property(rr => rr.Id)
//                     .HasColumnName("RoomRatingId")
//                     .ValueGeneratedNever()
//                     .HasConversion(id => id.Value, value => new(value));
//
//                 b.WithOwner().HasForeignKey(rr => rr.RoomId);
//                 b.Property(rr => rr.RoomId)
//                     .ValueGeneratedNever()
//                     .HasConversion(id => id.Value, value => new(value));
//
//                 // b.HasOne<Guest>()
//                 //     .WithMany()
//                 //     .HasForeignKey(rr => rr.GuestId);
//                 b.Property(rr => rr.GuestId)
//                     .ValueGeneratedNever()
//                     .HasConversion(id => id.Value, value => new(value));
//
//                 b.OwnsOne(
//                     rr => rr.Rate,
//                     r =>
//                     {
//                         r.Property(rr => rr.Type)
//                             .HasConversion(rate => rate.Name, name => RateType.FromName(name)!);
//                         r.Property(rr => rr.Description).HasMaxLength(50);
//                     }
//                 );
//             }
//         );
//
//         builder.Metadata
//             .FindNavigation(nameof(Room.RoomRatings))!
//             .SetPropertyAccessMode(PropertyAccessMode.Field);
//     }
//
//     private static void ConfigureRoom(EntityTypeBuilder<Room> builder)
//     {
//         builder.ToTable("Rooms");
//         builder.HasKey(r => r.Id);
//
//         builder
//             .Property(r => r.Id)
//             .ValueGeneratedNever()
//             .HasConversion(id => id.Value, value => new(value));
//
//         builder.HasOne<RoomType>().WithMany().HasForeignKey(r => r.RoomTypeId);
//         builder
//             .Property(r => r.RoomTypeId)
//             .ValueGeneratedNever()
//             .HasConversion(id => id.Value, value => new(value));
//
//         builder.Property(r => r.Name).HasMaxLength(5);
//     }
// }
