using Domain.User;

namespace Application.Users.Auth;

public record AuthenticationResult(
        User User,
        string Token);

