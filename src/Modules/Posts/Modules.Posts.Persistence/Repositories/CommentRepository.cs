using Modules.Posts.Domain.Entities;
using Modules.Posts.Domain.Interfaces;

namespace Modules.Posts.Persistence.Repositories
{
    public class CommentRepository : EntityBaseRepository<Comment>, ICommentRepository
    {
        private readonly PostContext _context;
        public CommentRepository(PostContext context) : base(context)
        {
            _context = context;
        }

        public Task<IQueryable<Comment>> GetCommentsByPostIdAsync(Guid postId)
        {
            return Task.FromResult(_context.Comments.Where(c => c.PostId == postId).AsQueryable());
        }

        public Task<IQueryable<Comment>> GetCommentsByUserIdAsync(string userId)
        {
            return Task.FromResult(_context.Comments.Where(c => c.UserId == userId).AsQueryable());
        }
    }
}
