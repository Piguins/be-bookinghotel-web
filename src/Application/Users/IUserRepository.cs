using Application.Abstractions.Persistence;
using Domain.User;
using Domain.User.ValueObjects;

namespace Application.Users;

public interface IUserRepository : IRepository<User, UserId>
{
    Task<User?> GetByEmailAsync(string email);
}
