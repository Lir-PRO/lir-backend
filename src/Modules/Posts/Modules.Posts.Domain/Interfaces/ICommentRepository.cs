using Modules.Posts.Domain.Entities;

namespace Modules.Posts.Domain.Interfaces
{
    public interface ICommentRepository : IEntityBaseRepository<Comment>
    {
        Task<IQueryable<Comment>> GetCommentsByPostIdAsync(Guid postId);
        Task<IQueryable<Comment>> GetCommentsByUserIdAsync(string userId);
    }
}
