using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common.Primitives;
using Domain.Guest.ValueObjects;
using Domain.Host.ValueObjects;
using Domain.User.Entities;
using Domain.User.ValuedObjects;

namespace Domain.User;
public class User : AggregateRoot<UserId>
{
    public User(UserId id) : base(id)
    {
    }

    public Person Person { get; }
    public HostId HostId { get; }
    public GuestId GuestId { get; }

}
