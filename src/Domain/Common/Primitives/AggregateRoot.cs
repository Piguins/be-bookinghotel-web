namespace Domain.Common.Primitives;

public abstract class AggregateRoot<TId> : Entity<TId>
    where TId : ValueObject
{
    protected AggregateRoot(TId id) : base(id)
    {
    }

#pragma warning disable CS8618
    protected AggregateRoot() { }
#pragma warning restore CS8618
}

