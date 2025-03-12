using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EfCore
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly RepositoryContext _context;

        protected RepositoryBase(RepositoryContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task DeleteAsync(T entity)
        {
            await Task.Run(()=> _context.Set<T>().Remove(entity));
        }

        public async Task<IQueryable<T>> FindAllAsync(bool trackChanges)
        {
            return await Task.Run(() =>
            !trackChanges ?
            _context.Set<T>().AsNoTracking() :
            _context.Set<T>()
            );
        }

        public async Task<IQueryable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return await Task.Run(() =>
            !trackChanges ?
            _context.Set<T>().Where(expression).AsNoTracking() :
            _context.Set<T>().Where(expression)
            );
        }

        public async Task<T> GetByIdAsync(int id, bool trackChanges)
        {
            // Başlangıçta sorguyu başlatıyoruz
            IQueryable<T> query = _context.Set<T>();

            // Eğer trackChanges false ise, AsNoTracking() kullanıyoruz
            if (!trackChanges)
                query = query.AsNoTracking();

            // Veriyi ID'ye göre çekiyoruz
            return await query.FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            await Task.Run(() => _context.Set<T>().Update(entity));
        }
    }
}
