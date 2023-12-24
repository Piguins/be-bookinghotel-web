using Domain.Common.Primitives;
using Domain.Common.ValueObjects;

namespace Application.Abstractions.Persistence;

public interface IRepository<TAggregate, TId>
    where TAggregate : AggregateRoot<TId>
    where TId : BaseId
{
    Task<List<TAggregate>> GetAllAsync();
    Task<TAggregate?> GetByIdAsync(TId id, CancellationToken cancellationToken = default);
    TAggregate Add(TAggregate aggregate);
    TAggregate Update(TAggregate aggregate);
    void Remove(TAggregate aggregate);
}
