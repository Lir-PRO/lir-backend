using Modules.Chats.Domain.Entities;

namespace Modules.Chats.Domain.Interfaces
{
    public interface IChatRepository : IEntityBaseRepository<Chat>
    {
        Task<IEnumerable<Chat>> GetChatsByUserIdAsync(string userId);
        Task<Guid> AddAsync(List<string> participantsIds);
    }
}
