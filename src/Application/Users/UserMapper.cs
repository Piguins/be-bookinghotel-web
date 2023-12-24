using Domain.Users;
using Domain.Users.Enums;
using Domain.Common.ValueObjects;

namespace Application.Users;

public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<BaseId, Guid>()
            .ConstructUsing(id => id.Value);
        CreateMap<Role, RoleResult>()
            .ConstructUsing(role => new RoleResult(role.Name, role.Value));
        CreateMap<User, UserResult>();
    }
}

