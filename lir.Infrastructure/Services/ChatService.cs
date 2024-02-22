using Lir.Core.Interfaces;
using Lir.Core.Models;
using Lir.Infrastructure.Persistence;
using Lir.Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
