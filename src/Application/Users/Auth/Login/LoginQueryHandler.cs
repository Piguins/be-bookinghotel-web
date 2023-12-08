using Application.Abstractions.Messaging;
using Domain.Common.Shared;
using Domain.User;

namespace Application.Users.Auth.Login;

internal sealed class LoginQueryHandler(
        IJwtTokenService jwtTokenService,
        IUserRepository userRepository)
    : IQueryHandler<LoginQuery, AuthenticationResult>
{
    public async Task<Result<AuthenticationResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        if (await userRepository.GetByEmailAsync(request.Email) is not User user)
        {
            return Result.Failure<AuthenticationResult>(DomainException.User.Auth.UserNotFound);
        }
        if (!User.VerifyPassword(request.Password, user.PasswordHash, user.PasswordSalt))
        {
            return Result.Failure<AuthenticationResult>(DomainException.User.Auth.WrongPassword);
        }

        string token = jwtTokenService.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}
