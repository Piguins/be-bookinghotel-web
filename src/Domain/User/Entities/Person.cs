using Domain.Common.Primitives;
using Domain.User.ValueObjects;

namespace Domain.User.Entities;

public class Person : Entity<PersonId>
{
    public Person(PersonId id) : base(id)
    {
    }

    public string  FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Country { get; set; }
}
