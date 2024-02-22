using Lir.Core.Interfaces;
using Lir.Core.Models;
using Lir.Infrastructure.Repositories.Base;
using Lir.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Lir.Infrastructure.Services
{
    public class PostService : EntityBaseRepository<Post>, IPostService
    {
        private readonly LirDbContext _context;
        public PostService(LirDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Post>> GetPostsByUserIdAsync(Guid userId)
        {
            return await _context.Posts.Where(c => c.UserId == userId).ToListAsync();
        }

        public async Task<IEnumerable<Post>> GetPostsByCategoryIdAsync(Guid categoryId)
        {
            return await _context.PostCategories.Where(pc => pc.CategoryId == categoryId)
                .Select(pc => pc.Post).ToListAsync();
        }
    }
}
