using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Users.ApplicationCore.Entities;
using Users.ApplicationCore.ValueObjects;
using Users.Infrastructure.Interfaces;
namespace Users.Infrastructure.Data;

public class UsersContext : IContext
{
    public IMongoCollection<UserEntity> Users { get; }
    public UsersContext(IOptions<DbSettings> dbSettings)
    {
        var dbClient = new MongoClient(dbSettings.Value.ConnectionString);
        var database = dbClient.GetDatabase(dbSettings.Value.DatabaseName);

        Users = database.GetCollection<UserEntity>(dbSettings.Value.CollectionName);
    }
}
