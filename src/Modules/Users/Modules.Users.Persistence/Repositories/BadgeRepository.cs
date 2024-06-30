using Modules.Users.Domain.Entities;
using Modules.Users.Domain.Interfaces;

namespace Modules.Users.Persistence.Repositories
{
    public class BadgeRepository : EntityBaseRepository<Badge>, IBadgeRepository
    {
        private readonly UserContext _context;
        public BadgeRepository(UserContext context) : base(context)
        {
            _context = context;
        }
    }
}
