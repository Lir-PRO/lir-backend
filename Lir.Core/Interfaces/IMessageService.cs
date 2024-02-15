using Lir.Core.Models;
using Lir.Core.Models.Interfaces;

namespace Lir.Core.Interfaces
{
    public interface IMessageService : IEntityBaseRepository<Message>
    {
        Task<IQueryable<Message>> GetMessagesByChatIdAsync(Guid chatId);
    }
}
