using Modules.Users.Domain.Entities;

namespace Modules.Users.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByEmailAsync(string email);
        Task<User> GetByUsernameAsync(string username);
        Task<IEnumerable<User>> GetUsersByBadgeId(Guid badgeId);
        Task<IEnumerable<User>> GetSubscribersByUserId(string userId);
        Task<IEnumerable<User>> GetSubscriptionsByUserId(string userId);
        Task AddAsync(User entity, CancellationToken cancellationToken);
        Task UpdateAsync(string id, User entity, CancellationToken cancellationToken);
        Task DeleteAsync(string id, CancellationToken cancellationToken);
    }
}