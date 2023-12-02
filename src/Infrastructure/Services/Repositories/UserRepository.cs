using Application.Users;
using Domain.User;
using Domain.User.ValueObjects;

namespace Infrastructure.Services.Repositories;

public class UserRepository : IUserRepository
{
    private static readonly List<User> Users = new();

    public Task<User> AddAsync(User aggregate) =>
        Task.Run(() =>
        {
            Users.Add(aggregate);
            return aggregate;
        });

    public Task DeleteAsync(UserId id) => throw new NotImplementedException();
    public Task<IEnumerable<User>> GetAllAsync() => throw new NotImplementedException();
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
