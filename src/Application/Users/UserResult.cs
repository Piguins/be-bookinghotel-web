namespace Application.Users;

public record UserResult(
    Guid Id,
    string Email,
    string FirstName,
    string LastName,
    List<RoleResult> Roles);

public record RoleResult(
    string Name,
    int Priority);
