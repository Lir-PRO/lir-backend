using Microsoft.EntityFrameworkCore;
using Modules.Users.Domain.Entities;
using Modules.Users.Domain.Interfaces;

namespace Modules.Users.Persistence.Repositories
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly UserContext _context;

        public SubscriptionRepository(UserContext context)
        {
            _context = context;
        }

        public async Task AddSubscription(string subscriberId, string userId)
        {
            var subscription = new UserSubscription()
            {
                SubscriberId = subscriberId,
                UserId = userId
            };

            await _context.UserSubscriptions.AddAsync(subscription);
        }

        public async Task DeleteSubscription(string subscriberId, string userId)
        {
            var subscription = await _context.UserSubscriptions
                .Where(us => us.SubscriberId == subscriberId && us.UserId == userId)
                .FirstOrDefaultAsync();

            if (subscription != null)
            {
                _context.UserSubscriptions.Remove(subscription);
                await _context.SaveChangesAsync();
            }
        }
    }
}
