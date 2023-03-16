namespace EventBus.Messages.Events;

public class UserCreatedEvent :IntegrationBaseEvent
{
    public UserCreatedEvent(): base(nameof(UserCreatedEvent))
    {

    }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public string Password { get; set; }
    public string UserName { get; set; }

}
