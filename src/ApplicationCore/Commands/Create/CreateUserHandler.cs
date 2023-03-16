using MediatR;
using Users.ApplicationCore.Domain;
using Users.ApplicationCore.Interfaces;

namespace Users.ApplicationCore.Commands;

public class CreateUserHandler : IRequestHandler<CreateUserCommand>
{
    private readonly IEventSourcingHandler<UserAggregate> _eventSourcingHandler;
    public CreateUserHandler(IEventSourcingHandler<UserAggregate> eventSourcingHandler)
    {
        _eventSourcingHandler = eventSourcingHandler ?? throw new ArgumentNullException();
    }
    public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {        
        var userData  = new UserData(request.UserName, request.Password);
        var userDetails = new UserDetails(request.FirstName, request.LastName,request.BirthDate);
        var aggregate = new UserAggregate(request.Id,userDetails,userData);

        await _eventSourcingHandler.SaveAsync(aggregate);

    }
}
