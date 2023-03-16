using Users.ApplicationCore.Domain;

namespace Users.ApplicationCore.Interfaces;

public interface IEventStoreRepository<T> where T : class
{
    Task SaveAsync(T @event);
    Task<List<T>> FindByAggregateId(Guid aggregateId);
    Task<List<T>> FindAllAsync();
}

