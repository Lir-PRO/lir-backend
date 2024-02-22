using Lir.Core.Interfaces;
using Lir.Core.Models;
using Lir.Infrastructure.Persistence;
using Lir.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Lir.Infrastructure.Services
{
    public class UserService : EntityBaseRepository<User>, IUserService
    {
        private readonly LirDbContext _context;
        public UserService(LirDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetUsersByChatId(Guid chatId)
        {
            return await _context.UserChats.Where(uc => uc.ChatId == chatId).Select(uc => uc.User).ToListAsync();
        }

        public async Task<IEnumerable<User>> GetUsersByBadgeId(Guid badgeId)
        {
            return await _context.UserBadges.Where(ub => ub.BadgeId == badgeId).Select(ub => ub.User).ToListAsync();
        }

        public async Task<IEnumerable<User>> GetSubscribersByUserId(Guid userId)
        {
            return await _context.UserSubscriptions.Where(us => us.UserId == userId).Select(us => us.Subscriber).ToListAsync();
        }

        public async Task<IEnumerable<User>> GetSubscriptionsByUserId(Guid userId)
        {
            return await _context.UserSubscriptions.Where(us => us.SubscriberId == userId).Select(us => us.User).ToListAsync();
        }
    }
}
