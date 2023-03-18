using Cqrs.Domain.Exceptions;
using EventBus.Messages.Events;
using EventBus.Messages.Events.Interfaces;
using Users.ApplicationCore.Exceptions;
using Users.ApplicationCore.Interfaces;
using Users.Infrastructure.Models;

namespace Users.Infrastructure.Stores;

public class EventStore : IEventStore
{
    private readonly IEventStoreRepository<EventModel> _eventStoreRepository;
    private readonly IEventProducer _eventProducer;

    public EventStore(IEventStoreRepository<EventModel> eventStoreRepository, IEventProducer eventProducer)
    {
        _eventStoreRepository = eventStoreRepository;
        _eventProducer = eventProducer;
    }
    public async Task<List<Guid>> GetAggregateIdsAsync()
    {
        var eventStream = await _eventStoreRepository.FindAllAsync();

        if (eventStream == null || !eventStream.Any())
            throw new ArgumentNullException(nameof(eventStream), "Could not retrieve event stream from the event store!");

        return eventStream.Select(x => x.AggregateIdentifier).Distinct().ToList();
    }

    public async Task<List<IntegrationBaseEvent>> GetEventsAsync(Guid aggregateId)
    {
        var eventStream = await _eventStoreRepository.FindByAggregateId(aggregateId);

        if (eventStream == null || !eventStream.Any())
            throw new AggregateNotFoundException("Incorrect User ID provided!");

        return eventStream.OrderBy(x => x.Version).Select(x => x.EventData).ToList();
    }

    public async Task SaveEventsAsync(Guid aggregateId, IEnumerable<IntegrationBaseEvent> events, int expectedVersion)
    {       
        var version = expectedVersion;

        foreach (var @event in events)
        {
            version++;
            @event.Version = version;
            var eventType = @event.GetType().Name;
            var eventModel = new EventModel
            {
                TimeStamp = DateTime.Now,
                AggregateIdentifier = aggregateId,
                Version = version,
                EventType = eventType,
                EventData = @event
            };

            await _eventStoreRepository.SaveAsync(eventModel);

            await _eventProducer.ProduceAsync(@event);
        }
    }
}
