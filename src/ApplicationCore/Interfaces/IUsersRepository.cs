using Users.Domain.Entities;

namespace Users.ApplicationCore.Interfaces;
public interface IUsersRepository :IRepository<UserEntity>
{
    Task<IEnumerable<UserEntity>> GetUsersByFilters(string firstName, string lastName, bool? hasConnected);
}
