using Modules.Chats.Domain.Entities;

namespace Modules.Chats.Domain.Interfaces
{
    public interface IChatService : IEntityBaseRepository<Chat>
    {
        Task<IEnumerable<Chat>> GetChatsByUserIdAsync(Guid userId);
    }
}
