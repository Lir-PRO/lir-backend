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
            var chats = await _context.UserChats.Where(uc => uc.UserId == userId).Select(n => n.Chat).ToListAsync();
            foreach (var chat in chats)
            {
                chat.UserChats = await _context.UserChats.Where(uc => uc.ChatId == chat.Id).ToListAsync();
            }

            return chats;
        }

        public async Task<Guid> AddAsync(List<string> participantsIds)
        {
            var chat = await _context.Chats.AddAsync(new Chat());
            await _context.SaveChangesAsync();

            foreach (var participantId in participantsIds)
            {
                var userChat = new UserChat()
                {
                    UserId = participantId,
                    ChatId = chat.Entity.Id
                };

                await _context.UserChats.AddAsync(userChat);
            }

            await _context.SaveChangesAsync();

            return chat.Entity.Id;
        }
    }
}
