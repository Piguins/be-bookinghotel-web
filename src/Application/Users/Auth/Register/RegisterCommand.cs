using Application.Abstractions.Mediator;

namespace Application.Users.Auth.Register;

public record RegisterCommand(
    string Email,
    string Password,
    string FirstName,
    string LastName) : ICommand<AuthenticationResult>;
