using DAL.Data;
using DAL.interfaces;
using Microsoft.EntityFrameworkCore;


namespace DAL.Repositories
{
    internal abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbSet<T> _dbSet;
        protected ApplicationContext _context;

        public Repository(ApplicationContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public abstract Task<T> GetByIdAsync(int id);
        public abstract Task<IEnumerable<T>> GetAllAsync();
        public async Task CreateAsync(T item)
        {
            await _dbSet.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T item)
        {
            _dbSet.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T item)
        {
            _dbSet.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}
