using Lir.Core.Interfaces;
using Lir.Core.Models;
using Lir.Infrastructure.Persistence;
using Lir.Infrastructure.Repositories.Base;

namespace Lir.Infrastructure.Services
{
    public class BadgeService : EntityBaseRepository<Badge>, IBadgeService
    {
        private readonly LirDbContext _context;
        public BadgeService(LirDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
