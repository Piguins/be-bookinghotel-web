using System.Security.Cryptography;
using Domain.User;

namespace Application.Users.Auth.Register;

internal sealed class RegisterCommandHandler(
        IJwtTokenService jwtTokenService,
        IUserRepository userRepository)
    : ICommandHandler<RegisterCommand, AuthenticationResult>
{
    public async Task<Result<AuthenticationResult>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        if (await userRepository.GetByEmailAsync(request.Email) is not null)
        {
            return Result.Failure<AuthenticationResult>(DomainException.User.EmailAlreadyExists);
        }

        using var hashAlgorithm = SHA256.Create();

        var user = User.Create(
            request.Email,
            request.FirstName,
            request.LastName,
            request.Password);

        string token = jwtTokenService.GenerateToken(user);
        await userRepository.AddAsync(user);

        return new AuthenticationResult(user, token);
    }
}
