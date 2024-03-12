using Lir.Core.Models.Interfaces;
using Lir.Core.Models;

namespace Lir.Core.Interfaces
{
    public interface IUserService : IEntityBaseRepository<User>
    {
        Task<User> GetUserByEmailAsync(string email);
        Task<User> GetUserByUsernameAsync(string username);
        Task<IEnumerable<User>> GetUsersByChatId(Guid chatId);
        Task<IEnumerable<User>> GetUsersByBadgeId(Guid badgeId);
        Task<IEnumerable<User>> GetSubscribersByUserId(Guid userId);
        Task<IEnumerable<User>> GetSubscriptionsByUserId(Guid userId);

    }
}
