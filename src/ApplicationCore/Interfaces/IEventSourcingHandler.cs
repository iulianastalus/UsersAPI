using Users.ApplicationCore.Domain;

namespace Users.ApplicationCore.Interfaces;

public interface IEventSourcingHandler<T> where T:AggregateRoot
{
    Task<bool> SaveAsync(T aggregate);
}

