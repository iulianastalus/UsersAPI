using EventBus.Messages.Events;

namespace Users.ApplicationCore.Interfaces;

public interface IEventStore
{
    Task SaveEventsAsync(Guid aggregateId, IEnumerable<IntegrationBaseEvent> events, int expectedVersion);
    Task<List<IntegrationBaseEvent>> GetEventsAsync(Guid aggregateId);
    Task<List<Guid>> GetAggregateIdsAsync();
    
}
