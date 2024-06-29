using Microsoft.EntityFrameworkCore;
using Modules.Users.Domain.Entities;
using Modules.Users.Domain.Interfaces;

namespace Modules.Users.Persistence.Services
{
    public class UserService : IUserService
    {
        private readonly UserContext _context;
        public UserService(UserContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users.Where(u => u.Email == email).FirstOrDefaultAsync();
        }

        public async Task<User> GetUserByUsernameAsync(string username)
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
    }
}
