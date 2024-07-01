using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Modules.Users.Persistence;

public class UserDbContextInitializer
{
    private readonly ILogger<UserDbContextInitializer> _logger;
    private readonly UserContext _context;

    public UserDbContextInitializer(ILogger<UserDbContextInitializer> logger,
        UserContext context)
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