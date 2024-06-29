using Modules.Users.Domain.Entities;
using Modules.Users.Domain.Interfaces;

namespace Modules.Users.Persistence.Services
{
    public class BadgeService : EntityBaseRepository<Badge>, IBadgeService
    {
        private readonly UserContext _context;
        public BadgeService(UserContext context) : base(context)
        {
            _context = context;
        }
    }
}
