using Common.Events;
using MassTransit;
using Modules.Chats.Domain.Entities;
using Modules.Chats.Persistence;

namespace Modules.Chats.Infrastructure.Consumers;

public class UserCreatedChatsConsumer : IConsumer<UserCreatedEvent>
{
    private readonly ChatContext _context;

    public UserCreatedChatsConsumer(ChatContext context)
    {
        _context = context;
    }

    public async Task Consume(ConsumeContext<UserCreatedEvent> context)
    {
        var user = new User
        {
            Id = context.Message.UserId,
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }
}
