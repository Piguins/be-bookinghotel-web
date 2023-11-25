using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common.ValueObjects;

namespace Domain.User.ValueObjects;
public sealed class PersonId : BaseId
{
    public PersonId(Guid value) : base(value)
    {
    }
}
