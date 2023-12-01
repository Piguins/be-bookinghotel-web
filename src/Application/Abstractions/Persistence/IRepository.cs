using Domain.Common.Primitives;
using Domain.Common.ValueObjects;

namespace Application.Abstractions.Persistence;

public interface IRepository<TAggregate, TId>
    where TAggregate : AggregateRoot<TId>
    where TId : BaseId
{
    Task<IEnumerable<TAggregate>> GetAllAsync();
    Task<TAggregate?> GetByIdAsync(TId id);
    Task<TAggregate> AddAsync(TAggregate aggregate);
    Task<TAggregate> UpdateAsync(TAggregate aggregate);
    Task DeleteAsync(TId id);
}
