namespace Modules.Users.Domain.Interfaces
{
    public interface ISubscriptionRepository
    {
        Task<bool> AddSubscription(string subscriberId, string userId);
        Task<bool> DeleteSubscription(string subscriberId, string userId);
    }
}
