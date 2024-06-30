using Microsoft.EntityFrameworkCore;
using Modules.Chats.Domain.Entities;
using Modules.Chats.Domain.Interfaces;

namespace Modules.Chats.Persistence.Repositories
{
    public class MessageRepository : EntityBaseRepository<Message>, IMessageRepository
    {
        private readonly ChatContext _context;
        public MessageRepository(ChatContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Message>> GetMessagesByChatIdAsync(Guid chatId)
        {
            return await _context.Messages.Where(m => m.ChatId == chatId).ToListAsync();
        }
    }
}
