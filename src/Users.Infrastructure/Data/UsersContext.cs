using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Users.ApplicationCore.Entities.UserAggregates;
using Users.ApplicationCore.ValueObjects;
using Users.Infrastructure.Interfaces;
namespace Users.Infrastructure.Data;

public class UsersContext : IContext
{
    public IMongoCollection<UserEntity> Users { get; }
    public UsersContext(IConfiguration configuration, IOptions<DbSettings> dbSettings)
    {
        var dbClient = new MongoClient(configuration.GetValue<string>(dbSettings.Value.ConnectionString));
        var database = dbClient.GetDatabase(configuration.GetValue<string>(dbSettings.Value.DatabaseName));

        Users = database.GetCollection<UserEntity>(configuration.GetValue<string>(dbSettings.Value.CollectionName));
    }
}
