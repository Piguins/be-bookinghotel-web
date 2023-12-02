using Application.Abstractions.Messaging;

namespace Application.Users.Auth.Login;

public record LoginCommand(string Email, string Password) : ICommand<AuthenticationResult>;
