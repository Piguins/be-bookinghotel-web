using Application.Abstractions.Messaging;
using Domain.Common.Shared;
using Domain.User;

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
            throw new InvalidOperationException("User does not exist");
        }
        if (!user.Password.Equals(request.Password, StringComparison.Ordinal))
        {
            throw new InvalidOperationException("Invalid password");
        }

        string token = jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}
