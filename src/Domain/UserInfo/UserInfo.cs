using Domain.Common.Primitives;
using Domain.UserInfo.ValueObjects;

namespace Domain.UserInfo;

public class UserInfo : Entity<UserInfoId>
{
    public UserInfo(UserInfoId id,
                  string country,
                  string phoneNo) : base(id)
    {
        Country = country;
        PhoneNo = phoneNo;
    }

    public string Country { get; private set; }
    public string PhoneNo { get; private set; }

    // #pragma warning disable CS8618
    //     private Person() { }
    // #pragma warning restore CS8618
}
