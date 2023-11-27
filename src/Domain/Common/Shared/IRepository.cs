using Domain.Common.Primitives;
using Domain.Common.ValueObjects;

namespace Domain.Common.Shared;

public interface IRepository<T, TId>
    where T : AggregateRoot<TId>
    where TId : BaseId
{
}
