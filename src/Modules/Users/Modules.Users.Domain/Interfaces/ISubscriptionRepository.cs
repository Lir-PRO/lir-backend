namespace Modules.Users.Domain.Interfaces
{
    public interface ISubscriptionRepository
    {
        Task AddSubscription(string subscriberId, string userId);
        Task DeleteSubscription(string subscriberId, string userId);
    }
}
