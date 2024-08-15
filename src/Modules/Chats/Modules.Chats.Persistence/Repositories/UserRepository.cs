using Microsoft.EntityFrameworkCore;
using Modules.Chats.Application.Common.Interfaces;
using Modules.Chats.Domain.Interfaces;

namespace Modules.Chats.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IChatContext _context;

    public UserRepository(IChatContext context)
    {
        _context = context;
    }

    public async Task<bool> UserExists(string id)
    {
        return await _context.Users.AnyAsync(u => u.Id == id);
    }
}