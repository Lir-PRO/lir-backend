using Modules.Chats.Domain.Entities;

namespace Modules.Chats.Domain.Interfaces
{
    public interface IMessageService : IEntityBaseRepository<Message>
    {
        Task<IEnumerable<Message>> GetMessagesByChatIdAsync(Guid chatId);
    }
}
