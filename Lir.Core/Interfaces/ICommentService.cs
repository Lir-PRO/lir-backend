using Lir.Core.Models;
using Lir.Core.Models.Interfaces;

namespace Lir.Core.Interfaces
{
    public interface ICommentService : IEntityBaseRepository<Badge>
    {
        Task<IQueryable<Comment>> GetCommentsByPostIdAsync(Guid postId);
        Task<IQueryable<Comment>> GetCommentsByUserIdAsync(Guid userId);
    }
}
