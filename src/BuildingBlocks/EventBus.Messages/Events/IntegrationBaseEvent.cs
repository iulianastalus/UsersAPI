namespace EventBus.Messages.Events;

public class IntegrationBaseEvent
{
    public int Version { get; set; }
    public DateTime CreatedDate { get; set; }
    public string EventType { get; private set; }
    public IntegrationBaseEvent(string eventType)
    {
        this.EventType= eventType;
    }
}
