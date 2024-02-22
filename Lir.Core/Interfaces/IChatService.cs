using Lir.Core.Models;
using Lir.Core.Models.Interfaces;

namespace Lir.Core.Interfaces
{
    public interface IChatService : IEntityBaseRepository<Chat>
    {
        Task<IEnumerable<Chat>> GetChatsByUserIdAsync(Guid userId);
    }
}
