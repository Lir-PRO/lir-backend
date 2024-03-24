using Lir.Core.Interfaces;
using Lir.Core.Models;
using Lir.Infrastructure.Persistence;
using Lir.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Lir.Infrastructure.Services
{
    public class ChatService : EntityBaseRepository<Chat>, IChatService
    {
        private readonly LirDbContext _context;
        public ChatService(LirDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Chat>> GetChatsByUserIdAsync(Guid userId)
        {
            return await _context.UserChats.Where(uc => uc.UserId == userId).Select(n => n.Chat).ToListAsync();
        }

        public async Task<Chat> AlreadyExists(Guid currentUserId, Guid targetUserId)
        {
            var chat = await _context.Chats
                .Where(chat => chat.UserChats.Any(uc => uc.UserId == currentUserId) && chat.UserChats.Any(uc => uc.UserId == targetUserId))
                .FirstOrDefaultAsync();

            return chat;
        }

        public async Task<Chat> AddChatAsync(List<Guid> participantsIds)
        {
            var chat = new Chat();
            await _context.Chats.AddAsync(chat);
            await _context.SaveChangesAsync();

            foreach (var participantId in participantsIds)
            {
                var userChat = new UserChat()
                {
                    ChatId = chat.Id,
                    UserId = participantId
                };
                await _context.UserChats.AddAsync(userChat);
                chat.UserChats.Add(userChat);
            }

            _context.Update(chat);
            await _context.SaveChangesAsync();
            return chat;
        }

    }
}
