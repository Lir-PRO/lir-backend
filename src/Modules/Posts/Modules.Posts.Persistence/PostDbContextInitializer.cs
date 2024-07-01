using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Modules.Posts.Persistence;

public class PostDbContextInitializer
{
    private readonly ILogger<PostDbContextInitializer> _logger;
    private readonly PostContext _context;

    public PostDbContextInitializer(ILogger<PostDbContextInitializer> logger,
        PostContext context)
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