

namespace EventBus.Messages.Events.Interfaces;

public interface IEventProducer
{
    Task ProduceAsync<T>(T @event) where T : IntegrationBaseEvent;
}
