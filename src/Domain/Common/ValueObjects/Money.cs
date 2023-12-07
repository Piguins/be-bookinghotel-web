using Domain.Common.Primitives;

namespace Domain.Common.ValueObjects;

public sealed class Money : ValueObject
{
    public static Money Usd => new("USD", 0);
    public static Money Vnd => new("VND", 1);

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

    public static Money Create(int currency, decimal amount)
    {
        switch (currency)
        {
            case 0:
                return new Money("USD", amount);
            default:
                return new Money("VND", amount);
        };
    }
}
