using Users.ApplicationCore.Domain;
using Users.ApplicationCore.Interfaces;

namespace Users.Infrastructure.Handlers
{
    public class EventSourcingHandler :IEventSourcingHandler<UserAggregate>
    {
        private readonly IEventStore _eventStore;

        public EventSourcingHandler(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }


        public async Task SaveAsync(UserAggregate aggregate)
        {
            await _eventStore.SaveEventsAsync(aggregate.Id, aggregate.GetUncommitedChanges(),aggregate.Version);
            aggregate.CommitChanges();
        }
    }
}
