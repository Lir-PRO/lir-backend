using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Modules.Users.Domain.Entities;
using Modules.Users.Domain.Interfaces;

namespace Modules.Users.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _context;
        public UserRepository(UserContext context)
        {
            _context = context;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.Users.Where(u => u.Email == email).FirstOrDefaultAsync();
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            return await _context.Users.Where(u => u.Username == username).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<User>> GetUsersByBadgeId(Guid badgeId)
        {
            return await _context.UserBadges.Where(ub => ub.BadgeId == badgeId).Select(ub => ub.User).ToListAsync();
        }

        public async Task<IEnumerable<User>> GetSubscribersByUserId(string userId)
        {
            return await _context.UserSubscriptions.Where(us => us.UserId == userId).Select(us => us.Subscriber).ToListAsync();
        }

        public async Task<IEnumerable<User>> GetSubscriptionsByUserId(string userId)
        {
            return await _context.UserSubscriptions.Where(us => us.SubscriberId == userId).Select(us => us.User).ToListAsync();
        }

        public async Task AddAsync(User entity, CancellationToken cancellationToken)
        {
            await _context.Users.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(string id, CancellationToken cancellationToken)
        {
            var entity = await _context.Users.FirstOrDefaultAsync(n => n.Id == id, cancellationToken);
            EntityEntry entityEntry = _context.Entry<User>(entity);
            entityEntry.State = EntityState.Deleted;

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(string id, User entity, CancellationToken cancellationToken)
        {
            EntityEntry entityEntry = _context.Entry<User>(entity);
            entityEntry.State = EntityState.Modified;

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
