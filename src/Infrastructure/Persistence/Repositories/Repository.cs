using Application.Abstractions.Persistence;
using Domain.Common.Primitives;
using Domain.Common.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public abstract class Repository<TAggregate, TId>(DbContext dbContext) : IRepository<TAggregate, TId>
    where TAggregate : AggregateRoot<TId>
    where TId : BaseId
{
    public virtual Task<List<TAggregate>> GetAllAsync() =>
        dbContext.Set<TAggregate>().ToListAsync();

    public virtual Task<TAggregate?> GetByIdAsync(TId id, CancellationToken cancellationToken = default) =>
        dbContext.Set<TAggregate>().FirstOrDefaultAsync(user =>
            user.Id.Equals(id), cancellationToken);

    public virtual TAggregate Add(TAggregate aggregate)
    {
        dbContext.Set<TAggregate>().Add(aggregate);
        return aggregate;
    }

    public virtual TAggregate Update(TAggregate aggregate)
    {
        dbContext.Set<TAggregate>().Update(aggregate);
        return aggregate;
    }

    public virtual void Remove(TAggregate aggregate) =>
        dbContext.Set<TAggregate>().Remove(aggregate);
}

