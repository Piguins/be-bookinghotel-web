using Application.Users;
using Domain.User;
using Domain.User.ValueObjects;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private static readonly List<User> Users = [User.DefaultHost()];

    public UserRepository(ILogger<UserRepository> logger)
    {
        logger.LogInformation("Default a host created: {User}", Users.First().Email);
    }

    public Task<User> AddAsync(User aggregate) =>
        Task.Run(() =>
        {
            Users.Add(aggregate);
            return aggregate;
        });

    public Task DeleteAsync(UserId id) => throw new NotImplementedException();
    public Task<IEnumerable<User>> GetAllAsync() =>
        Task.Run(() =>
        {
            return Users.AsEnumerable();
        });
    public Task<User?> GetByIdAsync(UserId id) =>
        Task.Run(() =>
        {
            return Users.FirstOrDefault(user =>
                user.Id.Equals(id));
        });
    public Task<User> UpdateAsync(User aggregate) => throw new NotImplementedException();

    public Task<User?> GetByEmailAsync(string email) =>
        Task.Run(() =>
        {
            return Users.FirstOrDefault(user =>
                user.Email.Equals(email, StringComparison.Ordinal));
        });

}
