namespace EventBus.Messages.Events;

public class UserCreatedEvent :IntegrationBaseEvent
{
    public UserCreatedEvent(): base(nameof(UserCreatedEvent))
    {

    }
    public Guid UserId { get; set; }
    public string FullName { get; set; }

}
