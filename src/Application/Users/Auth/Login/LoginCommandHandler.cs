using Application.Abstractions.Messaging;
using Domain.Common.Shared;
using Domain.User;
using Domain.User.Exceptions;

namespace Application.Users.Auth.Login;

internal sealed class LoginCommandHandler(
        IJwtTokenGenerator jwtTokenGenerator,
        IUserRepository userRepository)
    : ICommandHandler<LoginCommand, AuthenticationResult>
{
    public async Task<Result<AuthenticationResult>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        if (await userRepository.GetByEmailAsync(request.Email) is not User user)
        {
            return (Result<AuthenticationResult>)Result.Failure(DomainException.User.UserNotFound);
        }
        if (!user.Password.Equals(request.Password, StringComparison.Ordinal))
        {
            return (Result<AuthenticationResult>)Result.Failure(DomainException.User.WrongPassword);
        }

        string token = jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}
