

using Users.ApplicationCore.Domain;
using Users.Domain.Entities;

namespace Users.ApplicationCore.Interfaces;

public interface IRepository<T> where T: BaseEntity
{
    Task<T> GetById(Guid id);
    Task Create(T entity);
    Task<bool> Update(T entity);
    Task<bool> Delete(Guid id);
}
