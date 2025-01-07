using KoloroweWeb.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace KoloroweWeb.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly KolorowewebContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(KolorowewebContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<PaginatedList<T>> GetPaginatedAsync(int page, int pageSize)
        {
            return new PaginatedList<T>
            {
                Data = _dbSet.Skip((page - 1) * pageSize).Take(pageSize),
                TotalCount = await _dbSet.CountAsync()
            };
        }

        public async Task<T?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

        public async Task<T?> FindAsync(Expression<Func<T, bool>> predicate) =>
            await _dbSet.FirstOrDefaultAsync(predicate);

        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
