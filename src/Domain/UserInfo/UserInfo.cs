using Domain.Common.Primitives;
using Domain.UserInfo.ValueObjects;

namespace Domain.UserInfo;

public class UserInfo : Entity<UserInfoId>
{
    public UserInfo(UserInfoId id,
                  string firstName,
                  string lastName,
                  string country) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Country = country;
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Country { get; private set; }

    // #pragma warning disable CS8618
    //     private Person() { }
    // #pragma warning restore CS8618
}
