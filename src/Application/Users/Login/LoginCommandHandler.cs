using Application.Abstractions.Messaging;
using Domain.Common.Shared;

namespace Application.Users.Login;

internal sealed class LoginCommandHandler : ICommandHandler<LoginCommand, string>
{
    public Task<Result<string>> Handle(LoginCommand request, CancellationToken cancellationToken) => throw new NotImplementedException();
}
