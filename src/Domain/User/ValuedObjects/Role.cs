using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common.Primitives;

namespace Domain.User.ValuedObjects;
public class Role : ValueObject
{
    public string RoleName { get; set; } = null!;
    public string? Description { get; set; }
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return RoleName;
        yield return Description;
    }
}
