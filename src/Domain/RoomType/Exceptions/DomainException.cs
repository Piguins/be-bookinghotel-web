using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common.Shared;

namespace Domain.RoomType.Exceptions;
public static partial class DomainException
{
    public static class RoomType
    {
        //Money
        public static Error InvalidCurrency => new("Invalid Currency", "this currency number doesn't exist");
    }
}
