using System;
using Microsoft.EntityFrameworkCore;
using Parking.Domain.Core;
using System.Linq.Expressions;

namespace Parking.Infrastructure.Core
{
    public class BaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly DbContext _context;
        protected readonly DbSet<TEntity> _set;

        public BaseRepository(DbContext context)
        {
            _context = context;
            _set = context.Set<TEntity>();
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            _set.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<TEntity?> GetByIdAsync(int id)
            => await _set.FindAsync(id);

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
            => await _set.AsNoTracking().ToListAsync();

        public virtual async Task UpdateAsync(TEntity entity)
        {
            _set.Update(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(int id)
        {
            var e = await GetByIdAsync(id);
            if (e != null)
            {
                _set.Remove(e);
                await _context.SaveChangesAsync();
            }
        }

        // Opcional: búsqueda con predicado
        public virtual async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
            => await _set.Where(predicate).ToListAsync();
    }
}

