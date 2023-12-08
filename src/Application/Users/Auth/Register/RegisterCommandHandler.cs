using System.Security.Cryptography;
using Application.Abstractions.Messaging;
using Domain.Common.Shared;
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
            return Result.Failure<AuthenticationResult>(DomainException.User.Auth.EmailAlreadyExists);
        }

        using var hashAlgorithm = SHA256.Create();

        var user = User.Create(
            request.Email,
            request.FirstName,
            request.LastName,
            request.Password);
        await userRepository.AddAsync(user);

        string token = jwtTokenService.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}
