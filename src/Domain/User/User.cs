using Domain.Common.Primitives;
using Domain.User.ValueObjects;
using Domain.UserInfo.ValueObjects;

namespace Domain.User;

public class User : AggregateRoot<UserId>
{
    public User(UserId id,
                string email,
                string password,
                UserInfoId userInfoId) : base(id)
    {
        Email = email;
        Password = password;
        UserInfoId = userInfoId;
    }

    public string Email { get; private set; }
    public string Password { get; private set; }
    public UserInfoId UserInfoId { get; private set; }

    // #pragma warning disable CS8618
    //     private User() { }
    // #pragma warning restore CS8618
}
