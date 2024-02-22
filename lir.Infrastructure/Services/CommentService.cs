using Lir.Infrastructure.Repositories.Base;
using Lir.Core.Interfaces;
using Lir.Core.Models;
using Lir.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Lir.Infrastructure.Services
{
    public class CommentService : EntityBaseRepository<Comment>, ICommentService
    {
        private readonly LirDbContext _context;
        public CommentService(LirDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Comment>> GetCommentsByPostIdAsync(Guid postId)
        {
            return await _context.Comments.Where(c => c.PostId == postId).ToListAsync();
        }

        public async Task<IEnumerable<Comment>> GetCommentsByUserIdAsync(Guid userId)
        {
            return await _context.Comments.Where(c => c.UserId == userId).ToListAsync();
        }
    }
}
