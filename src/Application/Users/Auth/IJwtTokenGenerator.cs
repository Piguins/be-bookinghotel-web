using Domain.User;

namespace Application.Users.Auth;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
