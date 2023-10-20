using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common.Primitives;
using Domain.User.ValuedObjects;

namespace Domain.User.Entities;
public class Person : Entity<UserId>
{
    public Person(UserId id) : base(id)
    {
    }

    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string Region { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;
}
