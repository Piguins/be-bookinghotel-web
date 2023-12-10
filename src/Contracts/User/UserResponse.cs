namespace Contracts.User;

public record UserResponse(
    Guid UserId,
    string FirstName,
    string LastName,
    string Email,
    ICollection<RoleResponse> Roles);
