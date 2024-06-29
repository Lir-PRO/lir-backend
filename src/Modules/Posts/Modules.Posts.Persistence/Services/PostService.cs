using Microsoft.EntityFrameworkCore;
using Modules.Posts.Domain.Entities;
using Modules.Posts.Domain.Interfaces;

namespace Modules.Posts.Persistence.Services
{
    public class PostService : EntityBaseRepository<Post>, IPostService
    {
        private readonly PostContext _context;
        public PostService(PostContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Post>> GetPostsByUserIdAsync(string userId)
        {
            return await _context.Posts.Where(c => c.UserId == userId).ToListAsync();
        }

        public async Task<IEnumerable<Post>> GetPostsByCategoryIdAsync(Guid categoryId)
        {
            return await _context.PostCategories.Where(pc => pc.CategoryId == categoryId)
                .Select(pc => pc.Post).ToListAsync();
        }

        public async Task<Post> GetPostByIdAsync(Guid postId)
        {
            return await _context.Posts.Where(c => c.Id == postId).Include(p => p.Contents)
                .Include(p => p.PostCategories).ThenInclude(pc => pc.Category).FirstOrDefaultAsync();
        }
    }
}
