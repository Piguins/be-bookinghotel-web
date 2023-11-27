namespace Domain.Common.Primitives;

public abstract class AggregateRoot<TId> : Entity<TId>
    where TId : ValueObject
{
    protected AggregateRoot(TId id) : base(id)
    {
    }
}

