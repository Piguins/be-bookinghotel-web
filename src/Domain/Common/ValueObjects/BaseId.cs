using Domain.Common.Primitives;

namespace Domain.Common.ValueObjects;

public abstract class BaseId : ValueObject
{
    protected BaseId(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    protected static Guid Create() => Guid.NewGuid();

}

