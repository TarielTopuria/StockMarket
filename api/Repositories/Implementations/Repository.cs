using api.Data;
using api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories.Implementations
{
    public class Repository<T>(AppDbContext context) : IRepository<T> where T : class
    {
        private readonly DbContext context = context;
        private DbSet<T> entities = context.Set<T>();

        public async Task<IEnumerable<T>> GetAllAsync() => await entities.ToListAsync();

        public async Task<T> GetByIdAsync(object id) => await entities.FindAsync(id);

        public async Task InsertAsync(T obj) => await entities.AddAsync(obj);

        public async Task UpdateAsync(T obj) => context.Entry(obj).State = EntityState.Modified;

        public async Task DeleteAsync(object id)
        {
            T existing = await entities.FindAsync(id);
            entities.Remove(existing);
        }

        public async Task SaveAsync() => await context.SaveChangesAsync();
    }

}
