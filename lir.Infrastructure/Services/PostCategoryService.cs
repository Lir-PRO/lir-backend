using Lir.Core.Interfaces;
using Lir.Core.Models;
using Lir.Infrastructure.Persistence;

namespace Lir.Infrastructure.Services
{
    public class PostCategoryService : IPostCategoryService
    {
        private readonly LirDbContext _context;

        public PostCategoryService(LirDbContext context)
        {
            _context = context;
        }

        public async Task<PostCategory> AddAsync(PostCategory postCategory)
        {
            await _context.PostCategories.AddAsync(postCategory);
            await _context.SaveChangesAsync();
            return postCategory;
        }

        public void Delete(PostCategory postCategory)
        {
            _context.PostCategories.Remove(postCategory);
        }
    }
}
