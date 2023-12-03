using Application.Abstractions.Messaging;
using Domain.Common.Shared;
using Domain.User;

namespace Application.Users.Auth.Register;

internal sealed class RegisterCommandHandler : ICommandHandler<RegisterCommand, AuthenticationResult>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator,
                               IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<Result<AuthenticationResult>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        if (await _userRepository.GetByEmailAsync(request.Email) is not null)
        {
            throw new InvalidOperationException("User already exists");
        }

        var user = User.Create(
            request.Email,
            request.Password,
            request.FirstName,
            request.LastName);
        var add = _userRepository.AddAsync(user);

        string token = _jwtTokenGenerator.GenerateToken(user);

        Task.WaitAll(new Task[] { add },
                     cancellationToken);

        return new AuthenticationResult(user, token);
    }
}
