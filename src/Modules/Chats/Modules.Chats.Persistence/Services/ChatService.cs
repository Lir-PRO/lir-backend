using Microsoft.EntityFrameworkCore;
using Modules.Chats.Domain.Entities;
using Modules.Chats.Domain.Interfaces;

namespace Modules.Chats.Persistence.Services
{
    public class ChatService : EntityBaseRepository<Chat>, IChatService
    {
        private readonly ChatContext _context;
        public ChatService(ChatContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Chat>> GetChatsByUserIdAsync(Guid userId)
        {
            return await _context.UserChats.Where(uc => uc.UserId == userId).Select(n => n.Chat).ToListAsync();
        }
    }
}
