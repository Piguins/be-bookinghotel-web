namespace Application.Users.Auth.Register;

public record RegisterCommand(
    string Email,
    string Password,
    string FirstName,
    string LastName,
    bool IsHost) : ICommand<AuthenticationResult>;
