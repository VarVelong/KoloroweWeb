﻿using KoloroweWeb.Data.Entities;
using System.Linq.Expressions;

namespace KoloroweWeb.Data.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task AddAsync(T entity);
        Task<T?> GetByIdAsync(int id);
        Task<T?> FindAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAllAsync();
        Task<PaginatedList<T>> GetPaginatedAsync(int page, int pageSize);
        Task UpdateAsync(T entity);
        Task RemoveAsync(T entity);
    }
}
