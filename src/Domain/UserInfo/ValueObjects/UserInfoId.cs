using Domain.Common.ValueObjects;

namespace Domain.UserInfo.ValueObjects;

public sealed class UserInfoId : BaseId
{
    public UserInfoId(Guid value) : base(value)
    {
    }
}
