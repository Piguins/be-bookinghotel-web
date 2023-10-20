using Domain.Common.Primitives;

namespace Domain.Common.ValueObjects;

public sealed class Money : ValueObject
{
    public string Currency { get; set; } = string.Empty;

    public override IEnumerable<object> GetAtomicValues() => throw new NotImplementedException();
}
