using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _ctx;

        public Repository(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            return await _ctx.Set<T>().ToListAsync();
        }

        public async Task<T?> GetAsync(Guid id)
        {
            return await _ctx.Set<T>().FindAsync(id);
        }

        public async Task<Guid> CreateAsync(T entity)
        {
            await _ctx.Set<T>().AddAsync(entity);
            await _ctx.SaveChangesAsync();

            return entity.Id;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _ctx.Set<T>().FindAsync(id);

            if (entity == null)
            {
                return;
            }

            _ctx.Set<T>().Remove(entity);
            await _ctx.SaveChangesAsync();
        }

        public async Task<Guid> UpdateAsync(T entity)
        {
            _ctx.Set<T>().Update(entity);
            await _ctx.SaveChangesAsync();

            return entity.Id;
        }
    }
}
