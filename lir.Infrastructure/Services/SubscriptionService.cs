using Lir.Core.Interfaces;
using Lir.Core.Models;
using Lir.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Lir.Infrastructure.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly LirDbContext _context;

        public SubscriptionService(LirDbContext context)
        {
            _context = context;
        }

        public async Task AddSubscription(Guid subscriberId, Guid userId)
        {
            var subscription = new UserSubscription()
            {
                SubscriberId = subscriberId,
                UserId = userId
            };

            await _context.UserSubscriptions.AddAsync(subscription);
        }

        public async Task DeleteSubscription(Guid subscriberId, Guid userId)
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
