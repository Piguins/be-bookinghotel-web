using Application.Abstractions.Messaging;
using Domain.Common.Shared;
using Domain.User;

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
            throw new InvalidOperationException("User already exists");
        }

        var user = User.Create(
            request.Email,
            request.Password,
            request.FirstName,
            request.LastName);
        var add = userRepository.AddAsync(user);

        string token = jwtTokenGenerator.GenerateToken(user);

        Task.WaitAll(new Task[] { add },
                     cancellationToken);

        return new AuthenticationResult(user, token);
    }
}
