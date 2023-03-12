using MongoDB.Driver;
using Users.Domain.Entities;

namespace Users.Infrastructure.Interfaces;

public interface IContext
{
    public IMongoCollection<UserEntity> Users { get; }
}
