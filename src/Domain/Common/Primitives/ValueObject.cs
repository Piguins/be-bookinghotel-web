namespace Domain.Common.Primitives;

public abstract class ValueObject : IEquatable<ValueObject>
{
    public abstract IEnumerable<object> GetAtomicValues();

    public override bool Equals(object? obj) => obj is ValueObject temp && ValuesAreEqual(temp);

    public override int GetHashCode() =>
        GetAtomicValues().Aggregate(default(int), HashCode.Combine);

    private bool ValuesAreEqual(ValueObject temp) =>
        GetAtomicValues().SequenceEqual(temp.GetAtomicValues());

    public bool Equals(ValueObject? other) => other is not null && ValuesAreEqual(other);
}
