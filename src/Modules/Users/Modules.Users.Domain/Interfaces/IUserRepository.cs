using Modules.Users.Domain.Entities;

namespace Modules.Users.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmailAsync(string email);
        Task<User> GetUserByUsernameAsync(string username);
        Task<IEnumerable<User>> GetUsersByBadgeId(Guid badgeId);
        Task<IEnumerable<User>> GetSubscribersByUserId(string userId);
        Task<IEnumerable<User>> GetSubscriptionsByUserId(string userId);

    }
}