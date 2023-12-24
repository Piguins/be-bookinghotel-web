namespace Contracts.Auth;

public record AuthResponse(
    Guid Id,
    string Email,
    string FirstName,
    string LastName,
    bool IsHost,
    string Token);
