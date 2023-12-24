using Domain.Rooms.Entities;
using Domain.Rooms.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityFramework.Configurations.Rooms;

public class RoomImageConfiguration : IEntityTypeConfiguration<RoomImage>
{
    public void Configure(EntityTypeBuilder<RoomImage> builder) => ConfigureRoomImage(builder);

    private static void ConfigureRoomImage(EntityTypeBuilder<RoomImage> builder)
    {
        builder.HasKey(r => r.Id);

        builder
            .Property(r => r.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => RoomImageId.Create(value));

        builder
            .Property(r => r.RoomId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => RoomId.Create(value));
    }
}
