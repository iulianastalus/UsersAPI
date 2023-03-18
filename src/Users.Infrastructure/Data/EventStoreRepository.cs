using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Runtime;
using Users.ApplicationCore.Interfaces;
using Users.ApplicationCore.ValueObjects;
using Users.Infrastructure.Models;

namespace Users.Infrastructure.Data;

public class EventStoreRepository : IEventStoreRepository<EventModel>
{
    private readonly IMongoCollection<EventModel> _eventStoreCollection;
    private readonly IOptions<DbSettings> _config;
    public EventStoreRepository(IOptions<DbSettings> config)
    {
        _config = config;
        var mongoClient = new MongoClient(config.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(config.Value.DatabaseName);

        _eventStoreCollection = mongoDatabase.GetCollection<EventModel>(config.Value.EventsCollectionName);
    }
    public async Task<List<EventModel>> FindAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<List<EventModel>> FindByAggregateId(Guid aggregateId)
    {
        throw new NotImplementedException();
    }

    public async Task SaveAsync(EventModel @event)
    {
        await _eventStoreCollection.InsertOneAsync(@event).ConfigureAwait(false);
    }
}
