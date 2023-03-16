
using EventBus.Messages.Events.Interfaces;
using Users.ApplicationCore.Domain;
using Users.ApplicationCore.Interfaces;

namespace Users.Infrastructure.Handlers
{
    public class EventSourcingHandler :IEventSourcingHandler<UserAggregate>
    {
        private readonly IEventStore _eventStore;
        private readonly IEventProducer _eventProducer;

        public EventSourcingHandler(IEventStore eventStore, IEventProducer eventProducer)
        {
            _eventStore = eventStore;
            _eventProducer = eventProducer;
        }

        public async Task<UserAggregate> GetByIdAsync(Guid aggregateId)
        {
            throw new NotImplementedException();
        }


        public async Task SaveAsync(UserAggregate aggregate)
        {
            await _eventStore.SaveEventsAsync(aggregate.Id, aggregate.GetUncommitedChanges(),aggregate.Version);
            aggregate.CommitChanges();
        }
    }
}
