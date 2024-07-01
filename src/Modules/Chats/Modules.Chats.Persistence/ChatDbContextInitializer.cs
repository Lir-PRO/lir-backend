using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace Modules.Chats.Persistence;

public class ChatDbContextInitializer
{
    private readonly ILogger<ChatDbContextInitializer> _logger;
    private readonly ChatContext _context;

    public ChatDbContextInitializer(ILogger<ChatDbContextInitializer> logger,
        ChatContext context)
    {
        _logger = logger;
        _context = context;
    }
    public async Task InitialiseAsync()
    {
        try
        {
            if (_context.Database.IsNpgsql())
            {
                await _context.Database.MigrateAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
    }
}