using Domain.Rooms;
using Domain.Rooms.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityFramework.Configurations.Rooms;

public class RoomConfiguration : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder) => ConfigureRoom(builder);

    private static void ConfigureRoom(EntityTypeBuilder<Room> builder)
    {
        builder.HasKey(r => r.Id);

        builder
            .Property(r => r.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => RoomId.Create(value));

        builder
            .HasOne(x => x.Floor)
            .WithMany()
            .HasForeignKey("FloorId");

        builder.OwnsOne(x => x.Price);

        builder.HasMany(x => x.Images)
            .WithOne()
            .HasForeignKey(x => x.RoomId);
    }
}
