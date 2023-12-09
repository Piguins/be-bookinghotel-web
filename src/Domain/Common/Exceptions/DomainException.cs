using Domain.Common.Shared;

namespace Domain.Common.Exceptions;

public static partial class DomainException
{
    //Money
    public static Error InvalidCurrency => new("Invalid Currency", "this currency number doesn't exist");
    public static Error InvalidAmount => new("Invalid Amount", "this amount number doesn't exist");
    public static Error NotEnoughMoney => new("Not Enough Money", "this amount number doesn't exist");
}
