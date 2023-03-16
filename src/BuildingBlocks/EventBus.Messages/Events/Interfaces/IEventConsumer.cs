

namespace EventBus.Messages.Events.Interfaces;

internal interface IEventConsumer
{
    Task Consume(string topic);
}
