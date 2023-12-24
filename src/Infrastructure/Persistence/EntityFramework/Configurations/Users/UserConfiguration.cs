using Domain.Users;
using Domain.Users.Enums;
using Domain.Users.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.EntityFramework.Configurations.Users;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder) => ConfigureUser(builder);

    private static void ConfigureUser(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder
            .Property(u => u.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Value, value => UserId.Create(value));

        builder.HasMany(u => u.Roles)
            .WithMany()
            .UsingEntity<Dictionary<string, object>>(
                "UserRole",
                r => r.HasOne<Role>().WithMany().HasForeignKey("RoleId"),
                l => l.HasOne<User>().WithMany().HasForeignKey("UserId")
            );
    }
}
