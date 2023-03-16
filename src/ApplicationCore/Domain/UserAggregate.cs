using EventBus.Messages.Events;
using Users.ApplicationCore.Domain.Models;

namespace Users.ApplicationCore.Domain;

public class UserAggregate : AggregateRoot
{    
    public UserDetails UserDetails;
    public UserData UserData;
    public Audit Audit { get; set; }

    public UserAggregate(Guid id, UserDetails userDetails, UserData userData)
    {
        this.Id = id;
        UserData= userData;
        UserDetails = userDetails;

        RaiseEvent(new UserCreatedEvent
        {
            Id= id,
            FirstName = UserDetails.FirstName,
            LastName = UserDetails.LastName,
            BirthDate = UserDetails.BirthDate,
            UserName = UserData.UserName,
            Password = UserData.Password            
        });
    }

    public void Apply(UserCreatedEvent @event)
    {
        Id = @event.Id;
        Version = @event.Version;
        UserData = new UserData(@event.UserName, @event.Password );
        UserDetails = new UserDetails(@event.FirstName, @event.LastName, @event.BirthDate);
    }
}

public class UserDetails
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public UserDetails(string firstName, string lastName, DateTime birthDate)
    {
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
    }
}

public class UserData
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public UserData(string password, string userName)
    {
        Password = password;
        UserName = userName;
    }
}