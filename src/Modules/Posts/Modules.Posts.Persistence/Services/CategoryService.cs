using Modules.Posts.Domain.Entities;
using Modules.Posts.Domain.Interfaces;

namespace Modules.Posts.Persistence.Services
{
    public class CategoryService : EntityBaseRepository<Category>, ICategoryService
    {
        private readonly PostContext _context;
        public CategoryService(PostContext context) : base(context)
        {
            _context = context;
        }
    }
}
