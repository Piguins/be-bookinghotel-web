using System.Security.Cryptography;
using Application.Abstractions.Persistence;
using Domain.Users;

namespace Application.Users.Auth.Register;

internal sealed class RegisterCommandHandler(
        IUserRepository userRepository,
        IUnitOfWork unitOfWork,
        IJwtTokenService jwtTokenService)
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

        if (request.IsHost)
        {
            // user.AddHostRole();
        }

        string token = jwtTokenService.GenerateToken(user);
        userRepository.Add(user);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new AuthenticationResult(user, token);
    }
}
