using Modules.Posts.Domain.Entities;
using Modules.Posts.Domain.Interfaces;

namespace Modules.Posts.Persistence.Repositories
{
    public class CategoryRepository : EntityBaseRepository<Category>, ICategoryRepository
    {
        private readonly PostContext _context;
        public CategoryRepository(PostContext context) : base(context)
        {
            _context = context;
        }
    }
}
