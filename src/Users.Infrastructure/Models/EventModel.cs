

using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using EventBus.Messages.Events;

namespace Users.Infrastructure.Models;

public class EventModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public DateTime TimeStamp { get; set; }
    public Guid AggregateIdentifier { get; set; }
    public int Version { get; set; }
    public string EventType { get; set; }
    public IntegrationBaseEvent EventData { get; set; }
}
