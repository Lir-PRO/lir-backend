using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Modules.Users.Domain.Entities;
using Modules.Users.Domain.Interfaces;

namespace Modules.Users.Persistence.Repositories
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly UserContext _context;
        private readonly ILogger<SubscriptionRepository> _logger;

        public SubscriptionRepository(UserContext context, ILogger<SubscriptionRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> AddSubscription(string subscriberId, string userId)
        {
            try
            {
                var subscription = new UserSubscription()
                {
                    SubscriberId = subscriberId,
                    UserId = userId
                };

                await _context.UserSubscriptions.AddAsync(subscription);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Subscription added successfully for SubscriberId: {SubscriberId}, UserId: {UserId}", subscriberId, userId);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding subscription for SubscriberId: {SubscriberId}, UserId: {UserId}", subscriberId, userId);
                return false;
            }
        }

        public async Task<bool> DeleteSubscription(string subscriberId, string userId)
        {
            try
            {
                var subscription = await _context.UserSubscriptions
                    .Where(us => us.SubscriberId == subscriberId && us.UserId == userId)
                    .FirstOrDefaultAsync();

                if (subscription != null)
                {
                    _context.UserSubscriptions.Remove(subscription);
                    await _context.SaveChangesAsync();
                    _logger.LogInformation("Subscription deleted successfully for SubscriberId: {SubscriberId}, UserId: {UserId}", subscriberId, userId);
                    return true;
                }

                _logger.LogWarning("No subscription found for SubscriberId: {SubscriberId}, UserId: {UserId}", subscriberId, userId);
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting subscription for SubscriberId: {SubscriberId}, UserId: {UserId}", subscriberId, userId);
                return false;
            }
        }
    }
}
