using Common.Events;
using MassTransit;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Modules.Chats.Persistence;

namespace Modules.Chats.Infrastructure.Consumers;

public class UserDeletedConsumer : IConsumer<UserDeletedEvent>
{
    private readonly ChatContext _context;

    public UserDeletedConsumer(ChatContext context)
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
