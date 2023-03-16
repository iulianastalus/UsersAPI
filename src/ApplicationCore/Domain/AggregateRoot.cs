using EventBus.Messages.Events;

namespace Users.ApplicationCore.Domain;

public abstract class AggregateRoot
{
    public Guid Id {get; protected set;}
    private readonly List<IntegrationBaseEvent> _changes = new();
    public int Version { get; set; } = -1;
    public IEnumerable<IntegrationBaseEvent> GetUncommitedChanges()
    {
        return _changes;
    }
    public void CommitChanges()
    {
        _changes.Clear();
    }
    public void ApplyChange(IntegrationBaseEvent @event,bool isNew)
    {
        var t = this.GetType().GetMethods();
        var method = this.GetType().GetMethod("Apply",new Type[] {@event.GetType() });
        
        if (method == null)
        {
            throw new ArgumentNullException(nameof(method),$"The applied method was not found in the aggregate for {@event.GetType().Name}");
        }

        method.Invoke(this, new object[] { @event });
        if(isNew)
        {
            _changes.Add(@event);
        }
    }   

    protected void RaiseEvent(IntegrationBaseEvent @event)
    {
        ApplyChange( @event, true );
    }
}
