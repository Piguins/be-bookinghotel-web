using Application.Abstractions.Messaging;

namespace Application.Users.CreateUser;

public sealed record CreateUserCommand(
    string Email,
    string Password,
    string FirstName,
    string LastName) : ICommand;
