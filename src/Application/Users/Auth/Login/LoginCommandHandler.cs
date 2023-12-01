using Application.Abstractions.Messaging;
using Domain.Common.Shared;
using Domain.User;

namespace Application.Users.Auth.Login;

internal sealed class LoginCommandHandler : ICommandHandler<LoginCommand, AuthenticationResult>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public LoginCommandHandler(IJwtTokenGenerator jwtTokenGenerator,
                               IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<Result<AuthenticationResult>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        if (await _userRepository.GetByEmailAsync(request.Email) is not User user)
        {
            throw new InvalidOperationException("User does not exist");
        }
        if (!user.Password.Equals(request.Password, StringComparison.Ordinal))
        {
            throw new InvalidOperationException("Invalid password");
        }

        string token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}
