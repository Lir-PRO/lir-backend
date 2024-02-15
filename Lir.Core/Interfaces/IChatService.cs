using Lir.Core.Models;
using Lir.Core.Models.Interfaces;

namespace Lir.Core.Interfaces
{
    public interface IChatService : IEntityBaseRepository<Chat>
    {
        Task<IQueryable<Chat>> GetChatsByUserIdAsync(Guid userId);
    }
}
