using Application.Abstractions.Persistence;
using Domain.User;

namespace Infrastructure.Services.Repositories;

public class UserRepository : IUserRepository
{
    private static readonly List<User> Users = new();

    public User Add(User user)
    {
        Users.Add(user);
        return user;
    }

    public User? GetByEmail(string email) =>
        Users.FirstOrDefault(user =>
                user.Email.Equals(email, StringComparison.Ordinal));
}
