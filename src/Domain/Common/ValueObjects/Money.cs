using Domain.Common.Primitives;

namespace Domain.Common.ValueObjects;

public sealed class Money : ValueObject
{
    public static Money USD => new("USD", 0);
    public static Money VND => new("VND", 0);

    private Money(string currency, decimal amount)
    {
        Currency = currency;
        Amount = amount;
    }

    public string Currency { get; private set; }
    public decimal Amount { get; private set; }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Currency;
        yield return Amount;
    }
}
