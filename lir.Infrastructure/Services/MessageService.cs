using Lir.Core.Interfaces;
using Lir.Core.Models;
using Lir.Infrastructure.Repositories.Base;
using Lir.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Lir.Infrastructure.Services
{
    public class MessageService : EntityBaseRepository<Message>, IMessageService
    {
        private readonly LirDbContext _context;
        public MessageService(LirDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Message>> GetMessagesByChatIdAsync(Guid chatId)
        {
            return await _context.Messages.Where(m => m.ChatId == chatId).ToListAsync();
        }
    }
}
