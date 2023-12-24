namespace Domain.Common.Primitives;

public abstract class Entity<TId> : IEquatable<Entity<TId>>
    where TId : ValueObject
{
    public TId Id { get; private init; }

    protected Entity(TId id)
    {
        Id = id;
    }

    public static bool operator ==(Entity<TId>? first, Entity<TId>? second)
    {
        return first is not null && second is not null && first.Equals(second);
    }

    public static bool operator !=(Entity<TId>? first, Entity<TId>? second)
    {
        return !(first == second);
    }

    public override bool Equals(object? obj) =>
        obj is not null && obj.GetType() == GetType() && obj is Entity<TId> entity && entity.Id == Id;

    public bool Equals(Entity<TId>? other) =>
        other is not null && other.GetType() == GetType() && other.Id == Id;

    public override int GetHashCode() => Id.GetHashCode() * 123; // random number

#pragma warning disable CS8618
    protected Entity() { }
#pragma warning restore CS8618
}
