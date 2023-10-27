using Domain.Common.Primitives;
using Domain.User.ValueObjects;

namespace Domain.User.Entities;

public class Person : Entity<PersonId>
{
    public Person(PersonId id,
                  string firstName,
                  string lastName,
                  string email,
                  string country) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Country = country;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Country { get; set; }
}
