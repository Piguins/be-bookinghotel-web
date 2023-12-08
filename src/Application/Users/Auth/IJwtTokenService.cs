using Domain.User;

namespace Application.Users.Auth;

public interface IJwtTokenService
{
    string GenerateToken(User user);
}
