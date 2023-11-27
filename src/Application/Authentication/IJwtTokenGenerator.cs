using Domain.User;

namespace Application.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
