using Users.ApplicationCore.Domain;

namespace Users.ApplicationCore.Interfaces;

public interface IEventSourcingHandler<T> where T:AggregateRoot
{
    Task SaveAsync(T aggregate);
    Task<T> GetByIdAsync(Guid aggregateId);
}

