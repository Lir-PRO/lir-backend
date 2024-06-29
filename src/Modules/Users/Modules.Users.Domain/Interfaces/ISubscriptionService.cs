namespace Modules.Users.Domain.Interfaces
{
    public interface ISubscriptionService
    {
        Task AddSubscription(string subscriberId, string userId);
        Task DeleteSubscription(string subscriberId, string userId);
    }
}
