using Application.Abstractions.Persistence;
using Domain.Users;
using Domain.Users.ValueObjects;

namespace Application.Users;

public interface IUserRepository : IRepository<User, UserId>
{
    Task<User?> GetByEmailAsync(string email);
}
