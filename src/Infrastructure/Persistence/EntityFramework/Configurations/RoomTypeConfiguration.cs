// using Domain.Host;
// using Domain.Room;
// using Domain.RoomType;
// using Domain.RoomType.Enums;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata.Builders;
//
// namespace Infrastructure.Persistence.Configurations;
//
// public class RoomTypeConfiguration : IEntityTypeConfiguration<RoomType>
// {
//     public void Configure(EntityTypeBuilder<RoomType> builder)
//     {
//         ConfigureRoomType(builder);
//         ConfigureRoomIds(builder);
//     }
//
//     private static void ConfigureRoomIds(EntityTypeBuilder<RoomType> builder)
//     {
//         builder.OwnsMany(
//             rt => rt.RoomIds,
//             ri =>
//             {
//                 ri.ToTable("RoomTypeRoomIds");
//
//                 ri.HasKey("Id");
//                 ri.WithOwner().HasForeignKey("RoomTypeId");
//
//                 ri.Property(i => i.Value).HasColumnName("RoomId").ValueGeneratedNever();
//             }
//         );
//
//         builder.Metadata
//             .FindNavigation(nameof(RoomType.RoomIds))!
//             .SetPropertyAccessMode(PropertyAccessMode.Field);
//     }
//
//     private static void ConfigureRoomType(EntityTypeBuilder<RoomType> builder)
//     {
//         builder.ToTable("RoomTypes");
//         builder.HasKey(rt => rt.Id);
//
//         builder
//             .Property(rt => rt.Id)
//             .ValueGeneratedNever()
//             .HasConversion(id => id.Value, value => new(value));
//
//         builder
//             .Property(rt => rt.Floor)
//             .HasConversion(floor => floor.Name, name => Floor.FromName(name)!);
//
//         builder.OwnsOne(
//             rt => rt.Price,
//             pb =>
//             {
//                 pb.Property(p => p.Currency).HasMaxLength(3);
//             }
//         );
//
//         // builder.HasOne<Host>().WithMany().HasForeignKey(rt => rt.HostId);
//         builder
//             .Property(rt => rt.HostId)
//             .ValueGeneratedNever()
//             .HasConversion(id => id.Value, value => new(value));
//     }
// }
