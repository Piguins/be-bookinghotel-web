using Domain.Common.Primitives;
using Domain.Common.ValueObjects;
using Domain.User.Enums;
using Domain.User.ValueObjects;
using Domain.UserInfo.ValueObjects;

namespace Domain.User;

public class User : AggregateRoot<UserId>
{
    private readonly List<Role> _roles = new();

    private User(UserId id,
                 string email,
                 string password,
                 string firstName,
                 string lastName)
        : base(id)
    {
        Email = email;
        Password = password;
        FirstName = firstName;
        LastName = lastName;
    }

    public string Email { get; private set; }
    public string Password { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public UserInfoId UserInfoId { get; private set; } = null!;
    public IReadOnlyList<Role> Roles => _roles.AsReadOnly();

    public static User Create(string email,
                              string password,
                              string firstName,
                              string lastName) =>
        new(
            UserId.Create(BaseId.NewId),
            email,
            password,
            firstName,
            lastName);


    // #pragma warning disable CS8618
    //     private User() { }
    // #pragma warning restore CS8618
}
