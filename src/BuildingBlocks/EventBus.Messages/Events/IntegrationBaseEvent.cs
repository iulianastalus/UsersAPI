namespace EventBus.Messages.Events;

public class IntegrationBaseEvent
{
    public Guid Id { get; set; }
    public string EventType { get; private set; }
    public int Version { get; set; }
    public IntegrationBaseEvent(string eventType)
    {
        this.EventType= eventType;
    }
}
