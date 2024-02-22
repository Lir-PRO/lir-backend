using Lir.Core.Models;
using Lir.Core.Models.Interfaces;

namespace Lir.Core.Interfaces
{
    public interface ICommentService : IEntityBaseRepository<Comment>
    {
        Task<IEnumerable<Comment>> GetCommentsByPostIdAsync(Guid postId);
        Task<IEnumerable<Comment>> GetCommentsByUserIdAsync(Guid userId);
    }
}
