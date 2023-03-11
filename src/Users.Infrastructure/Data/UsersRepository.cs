

using MongoDB.Driver;
using Users.ApplicationCore.Entities.UserAggregates;
using Users.ApplicationCore.Interfaces;
using Users.Infrastructure.Interfaces;

namespace Users.Infrastructure.Data;

public class UsersRepository : IUsersRepository
{
    private readonly IContext _context;

    public UsersRepository(IContext context)
    {
        _context= context ?? throw new ArgumentNullException(nameof(context));
    }
    public async Task Create(UserEntity entity)
    {
         await _context.Users.InsertOneAsync(entity);
    }

    public Task<bool> Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<UserEntity> GetById(Guid id)
    {
        return await _context.Users.Find(z => z.Id == id).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<UserEntity>> GetUsersByFilters(string firstName, string lastName, bool? hasConnected)
    {
        FilterDefinition<UserEntity> filter = Builders<UserEntity>.Filter.And(Builders<UserEntity>.Filter.ElemMatch(p => p.FirstName, firstName),
                                                                              Builders<UserEntity>.Filter.ElemMatch(p => p.LastName, lastName),
                                                                               Builders<UserEntity>.Filter.Eq(p => p.AuditTrail.Any(), hasConnected));

        return await _context.Users.Find(filter).ToListAsync();
    }

    public async Task<bool> Update(UserEntity entity)
    {
        var updateResult = await _context.Users.ReplaceOneAsync(filter: p => p.Id == entity.Id, replacement: entity);
        return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
    }
}
