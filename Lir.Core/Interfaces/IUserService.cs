using Lir.Core.Models.Interfaces;
using Lir.Core.Models;

namespace Lir.Core.Interfaces
{
    public interface IUserService : IEntityBaseRepository<User>
    {
        Task<IQueryable<User>> GetUsersByChatId(Guid chatId);
        Task<IQueryable<User>> GetUsersByBadgeId(Guid badgeId);
        Task<IQueryable<User>> GetSubscribersByUserId(Guid userId);
        Task<IQueryable<User>> GetSubscriptionsByUserId(Guid userId);

    }
}
