

namespace EventBus.Messages.Events.Interfaces;

public interface IEventProducer
{
    Task ProduceAsync<T>(string topic, T @event) where T : IntegrationBaseEvent;
}
