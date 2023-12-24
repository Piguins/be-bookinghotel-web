using Domain.Bookings;
using Domain.Bookings.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityFramework.Configurations.Bookings;

public class BookingConfiguration : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder) => ConfigureBooking(builder);

    private static void ConfigureBooking(EntityTypeBuilder<Booking> builder)
    {
        builder.ToTable("Bookings");
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id)
            .ValueGeneratedNever()
            .HasConversion(
                    id => id.Value,
                    value => BookingId.Create(value));

        builder.HasOne(x => x.User)
            .WithMany();

        builder.HasOne(x => x.Floor)
            .WithMany()
            .HasForeignKey("FloorId");

        builder
            .Property(x => x.OrderId)
            .HasConversion(
                id => id.Value,
                value => OrderId.Create(value));
    }
}

