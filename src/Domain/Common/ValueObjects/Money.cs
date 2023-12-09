using Domain.Common.Primitives;

namespace Domain.Common.ValueObjects;

public sealed class Money : ValueObject
{
    public static Money Usd => new("USD", 0);
    public static Money Vnd => new("VND", 0);

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

    public Money Add(decimal amount)
    {
        Amount += amount;
        return this;
    }
    public Money WithDraw(decimal amount)
    {
        if (Amount < amount)
        {
            throw new Exception("Not enough money");
        }
        Amount -= amount;
        return this;
    }

    public static Money FromCurrency(string currency)
    {
        return currency.ToUpper() switch
        {
            "USD" => Usd,
            "VND" => Vnd,
            _ => throw new Exception("Invalid Currency")
        };
    }
}
