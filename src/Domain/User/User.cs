using Domain.Common.Primitives;
using Domain.Guest.ValueObjects;
using Domain.Host.ValueObjects;
using Domain.User.Entities;
using Domain.User.ValueObjects;

namespace Domain.User;
public class User : AggregateRoot<UserId>
{
    public User(UserId id,
                Person person,
                HostId hostId,
                GuestId guestId) : base(id)
    {
        Person = person;
        HostId = hostId;
        GuestId = guestId;
    }

    public Person Person { get; }
    public HostId HostId { get; }
    public GuestId GuestId { get; }

}
