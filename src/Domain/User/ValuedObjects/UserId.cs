using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common.ValueObjects;

namespace Domain.User.ValuedObjects;
public class UserId : BaseId
{
    public UserId(Guid value) : base(value)
    {
    }
}
