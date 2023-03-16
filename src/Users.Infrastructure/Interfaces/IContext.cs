using MongoDB.Driver;
using Users.ApplicationCore.Entities;

namespace Users.Infrastructure.Interfaces;

public interface IContext
{
    public IMongoCollection<UserEntity> Users { get; }
}
