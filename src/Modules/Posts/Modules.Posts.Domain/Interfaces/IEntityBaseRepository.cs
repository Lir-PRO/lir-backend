using System.Linq.Expressions;
using Modules.Posts.Domain.Common;

namespace Modules.Posts.Domain.Interfaces
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<T> GetByIdAsync(Guid id, params Expression<Func<T, object>>[] includeProperties);
        Task AddAsync(T entity, CancellationToken cancellationToken);
        Task UpdateAsync(Guid id, T entity, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
