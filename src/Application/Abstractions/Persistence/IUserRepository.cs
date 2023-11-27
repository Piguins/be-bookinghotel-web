using Domain.User;

namespace Application.Abstractions.Persistence;

public interface IUserRepository
{
    User? GetByEmail(string email);
    User Add(User user);
}
