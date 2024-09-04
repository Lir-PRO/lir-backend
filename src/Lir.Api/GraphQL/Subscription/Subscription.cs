using Modules.Chats.Endpoints.GraphQL.Subscriptions;

namespace Lir.Api.GraphQL.Subscription;

public class Subscription
{
    public ChatSubscriptions ChatSubscriptions { get; set; }

    public Subscription(ChatSubscriptions chatSubscriptions)
    {
        ChatSubscriptions = chatSubscriptions;
    }
}