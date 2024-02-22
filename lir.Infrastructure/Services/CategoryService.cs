using Lir.Core.Interfaces;
using Lir.Core.Models;
using Lir.Infrastructure.Persistence;
using Lir.Infrastructure.Repositories.Base;

namespace Lir.Infrastructure.Services
{
    public class CategoryService : EntityBaseRepository<Category>, ICategoryService
    {
        private readonly LirDbContext _context;
        public CategoryService(LirDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
