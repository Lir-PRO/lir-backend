using Common.Events;
using MassTransit;
using Modules.Posts.Domain.Entities;
using Modules.Posts.Persistence;

namespace Modules.Posts.Infrastructure.Consumers;

public class UserCreatedPostsConsumer : IConsumer<UserCreatedEvent>
{
    private readonly PostContext _context;

    public UserCreatedPostsConsumer(PostContext context)
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
