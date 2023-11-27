using Application.Abstractions.Messaging;

namespace Application.Users.Login;

public record LoginCommand(string Email, string Password) : ICommand<string>;
