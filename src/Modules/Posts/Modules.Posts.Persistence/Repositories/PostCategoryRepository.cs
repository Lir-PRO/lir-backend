using Microsoft.EntityFrameworkCore;
using Modules.Posts.Domain.Entities;
using Modules.Posts.Domain.Interfaces;

namespace Modules.Posts.Persistence.Repositories
{
    public class PostCategoryRepository : IPostCategoryRepository
    {
        private readonly PostContext _context;

        public PostCategoryRepository(PostContext context)
        {
            _context = context;
        }

        public async Task<PostCategory> AddAsync(PostCategory postCategory)
        {
            await _context.PostCategories.AddAsync(postCategory);
            await _context.SaveChangesAsync();
            return postCategory;
        }

        public async Task<ICollection<PostCategory>> GetByPostId(Guid id)
        {
           return await _context.PostCategories.Where(pc => pc.PostId == id)
               .Include(pc => pc.Category)
               .ToListAsync();
        }

        public async void Delete(PostCategory postCategory)
        {
            _context.PostCategories.Remove(postCategory);
            await _context.SaveChangesAsync();
        }
    }
}
