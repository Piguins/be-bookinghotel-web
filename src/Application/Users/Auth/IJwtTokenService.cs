using Domain.Users;

namespace Application.Users.Auth;

public interface IJwtTokenService
{
    string GenerateToken(User user);
}
