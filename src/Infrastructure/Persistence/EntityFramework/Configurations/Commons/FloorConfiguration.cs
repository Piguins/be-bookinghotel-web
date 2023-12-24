using Domain.Common.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityFramework.Configurations.Commons;

public class FloorConfiguration : IEntityTypeConfiguration<Floor>
{
    public void Configure(EntityTypeBuilder<Floor> builder)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        ConfigureFloor(builder);
    }

    private static void ConfigureFloor(EntityTypeBuilder<Floor> builder)
    {
        builder.HasKey(u => u.Value);

        builder.Property(u => u.Value)
            .HasColumnName("Id");

        builder.HasData(Floor.GetValues());
    }
}

