using Application.Users;
using Domain.Users;
using Domain.Users.Enums;
using Domain.Users.ValueObjects;
using Infrastructure.Persistence.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class UserRepository(ApplicationDbContext dbContext) : Repository<User, UserId>(dbContext), IUserRepository
{
    public override User Add(User aggregate)
    {
        if (dbContext.Roles.FirstOrDefault(x => x.Equals(Role.Guest)) is not { } guestRole)
        {
            throw new InvalidOperationException("Customer role not found");
        }
        aggregate.Roles.Add(guestRole);
        dbContext.Users.Add(aggregate);
        return aggregate;
    }

    public override Task<List<User>> GetAllAsync() =>
        dbContext.Users
            .Include(x => x.Roles)
            .ToListAsync();

    public override Task<User?> GetByIdAsync(UserId id, CancellationToken cancellationToken = default) =>
        dbContext.Users
            .Include(x => x.Roles)
            .FirstOrDefaultAsync(user =>
                user.Id.Equals(id), cancellationToken);

    public Task<User?> GetByEmailAsync(string email) =>
        dbContext.Users.FirstOrDefaultAsync(x =>
            x.Email == email);

    public Task<Role?> GetRoleAsync(Role role) =>
        dbContext.Roles.FirstOrDefaultAsync(x =>
            x.Equals(role));
}

