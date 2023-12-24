using Domain.Users.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityFramework.Configurations.Users;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        ArgumentNullException.ThrowIfNull(builder, nameof(builder));
        ConfigureRole(builder);
    }

    private static void ConfigureRole(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(u => u.Value);

        builder.Property(u => u.Value)
            .HasColumnName("Id");

        builder.HasData(Role.GetValues());
    }
}

