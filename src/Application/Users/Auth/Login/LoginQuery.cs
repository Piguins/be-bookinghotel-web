namespace Application.Users.Auth.Login;

public record LoginQuery(string Email, string Password) : IQuery<AuthenticationResult>;
