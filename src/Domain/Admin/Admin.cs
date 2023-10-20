using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Primitives;

namespace Domain.Admin;
internal class Admin : Entity
{
    public Admin(Guid id) : base(id)
    {
    }
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public Guid? PersonInfoId { get; set; }
}
