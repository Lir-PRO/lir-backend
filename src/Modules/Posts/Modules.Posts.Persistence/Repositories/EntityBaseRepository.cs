using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Modules.Posts.Domain.Common;
using Modules.Posts.Domain.Interfaces;

namespace Modules.Posts.Persistence.Repositories
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        private readonly PostContext _context;
        public EntityBaseRepository(PostContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity, CancellationToken cancellationToken)
        {
            await _context.Set<T>().AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _context.Set<T>().FirstOrDefaultAsync(n => n.Id == id, cancellationToken);
            if (entity == null)
            {
                return false;
            }

            EntityEntry entityEntry = _context.Entry(entity);
            entityEntry.State = EntityState.Deleted;

            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken) => await _context.Set<T>().ToListAsync(cancellationToken);

        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return await query.ToListAsync();

        }

        public async Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken) => await _context.Set<T>().FirstOrDefaultAsync(n => n.Id == id, cancellationToken);

        public async Task<T> GetByIdAsync(Guid id, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return await query.FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task UpdateAsync(Guid id, T entity, CancellationToken cancellationToken)
        {
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
