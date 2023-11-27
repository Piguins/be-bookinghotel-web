using Application.Abstractions.Persistence;
using Domain.User;

namespace Application.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(
        IJwtTokenGenerator jwtTokenGenerator,
        IUserRepository userRepository
    )
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public AuthenticationResult Login(string email, string password)
    {
        if (_userRepository.GetByEmail(email) is not User user)
        {
            throw new InvalidOperationException("User does not exist");
        }
        if (!user.Password.Equals(password, StringComparison.Ordinal))
        {
            throw new InvalidOperationException("Invalid password");
        }

        string token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }

    public AuthenticationResult Register(
        string email,
        string password,
        string firstName,
        string lastName
    )
    {
        if (_userRepository.GetByEmail(email) is not null)
        {
            throw new InvalidOperationException("User already exists");
        }

        var user = User.Create(email, password, firstName, lastName);
        _userRepository.Add(user);

        string token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}
