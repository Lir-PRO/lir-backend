using Modules.Posts.Domain.Entities;
using Modules.Posts.Domain.Interfaces;

namespace Modules.Posts.Persistence.Services
{
    public class CommentService : EntityBaseRepository<Comment>, ICommentService
    {
        private readonly PostContext _context;
        public CommentService(PostContext context) : base(context)
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
