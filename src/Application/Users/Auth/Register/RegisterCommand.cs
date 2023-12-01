using Application.Abstractions.Messaging;

namespace Application.Users.Auth.Register;

public record RegisterCommand(
    string Email,
    string Password,
    string FirstName,
    string LastName) : ICommand<AuthenticationResult>;
