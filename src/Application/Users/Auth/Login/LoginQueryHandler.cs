using Domain.Users;

namespace Application.Users.Auth.Login;

internal sealed class LoginQueryHandler(
        IJwtTokenService jwtTokenService,
        IUserRepository userRepository)
    : IQueryHandler<LoginQuery, AuthenticationResult>
{
    public async Task<Result<AuthenticationResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        if (await userRepository.GetByEmailAsync(request.Email) is not { } user)
        {
            return Result.Failure<AuthenticationResult>(DomainException.User.UserNotFound);
        }
        if (!user.VerifyPassword(request.Password))
        {
            return Result.Failure<AuthenticationResult>(DomainException.User.WrongPassword);
        }

        string token = jwtTokenService.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}
