using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common.Primitives;
using Domain.User.Entities;
using Domain.User.ValuedObjects;

namespace Domain.User;
public class User : AggregateRoot<UserId>
{
    public User(UserId id) : base(id)
    {
    }

    public IEnumerable<Role> Roles { get; set; } = null!;
    public Person? Person { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
