using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories.Interface
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<ICollection<T>> GetAllAsync();

        Task<T?> GetAsync(Guid id);

        Task<Guid> CreateAsync(T entity);

        Task<Guid> UpdateAsync(T entity);

        Task DeleteAsync(Guid id);
    }
}
