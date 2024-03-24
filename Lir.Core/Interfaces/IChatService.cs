using Lir.Core.Models;

namespace Lir.Core.Interfaces
{
    public interface IChatService : IEntityBaseRepository<Chat>
    {
        Task<IEnumerable<Chat>> GetChatsByUserIdAsync(Guid userId);
        Task<Chat> AlreadyExists(Guid currentUserId, Guid targetUserId);
        Task<Chat> AddChatAsync(List<Guid> participantsIds);
    }
}
