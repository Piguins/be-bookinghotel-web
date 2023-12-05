using Application.Abstractions.Messaging;
using Domain.Common.Shared;
using Domain.User;
using Domain.User.Exceptions;

namespace Application.Users.Auth.Register;

internal sealed class RegisterCommandHandler(
        IJwtTokenGenerator jwtTokenGenerator,
        IUserRepository userRepository)
    : ICommandHandler<RegisterCommand, AuthenticationResult>
{
    public async Task<Result<AuthenticationResult>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        if (await userRepository.GetByEmailAsync(request.Email) is not null)
        {
            return (Result<AuthenticationResult>)Result.Failure(DomainException.User.EmailAlreadyExists);
        }

        var user = User.Create(
            request.Email,
            request.Password,
            request.FirstName,
            request.LastName);
        await userRepository.AddAsync(user);

        string token = jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}
