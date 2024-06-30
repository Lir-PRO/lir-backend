using Microsoft.EntityFrameworkCore;
using Modules.Chats.Domain.Entities;
using Modules.Chats.Domain.Interfaces;

namespace Modules.Chats.Persistence.Repositories
{
    public class ChatRepository : EntityBaseRepository<Chat>, IChatRepository
    {
        private readonly ChatContext _context;
        public ChatRepository(ChatContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Chat>> GetChatsByUserIdAsync(string userId)
        {
            return await _context.UserChats.Where(uc => uc.UserId == userId).Select(n => n.Chat).ToListAsync();
        }
    }
}
