using Lir.Core.Interfaces;
using Lir.Core.Models;
using Lir.Infrastructure.Persistence;
using Lir.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Lir.Infrastructure.Services
{
    public class UserRolesService : EntityBaseRepository<UserRoles>, IUserRolesService
    {
        private readonly LirDbContext _context;
        public UserRolesService(LirDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserRoles>> GetByUserId(Guid userId)
        {
            return await _context.UserRoles.Where(ur => ur.UserId == userId).ToListAsync();
        }
    }
}
