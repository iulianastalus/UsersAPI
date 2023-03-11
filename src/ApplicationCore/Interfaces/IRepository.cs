

namespace Users.ApplicationCore.Interfaces;

public interface IRepository<T> where T : IAggregateRoot
{
    Task<T> GetById(Guid id);
    Task Create(T entity);
    Task<bool> Update(T entity);
    Task<bool> Delete(Guid id);
}
