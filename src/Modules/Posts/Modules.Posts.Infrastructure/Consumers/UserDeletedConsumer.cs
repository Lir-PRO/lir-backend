using Common.Events;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Modules.Posts.Persistence;

namespace Modules.Posts.Infrastructure.Consumers;

public class UserDeletedConsumer : IConsumer<UserDeletedEvent>
{
    private readonly PostContext _context;

    public UserDeletedConsumer(PostContext context)
    {
        _context = context;
    }

    public async Task Consume(ConsumeContext<UserDeletedEvent> context)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == context.Message.UserId);

        EntityEntry entityEntry = _context.Entry(user);
        entityEntry.State = EntityState.Deleted;

        await _context.SaveChangesAsync();
    }
}