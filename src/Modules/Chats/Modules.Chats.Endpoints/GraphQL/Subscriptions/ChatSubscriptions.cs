using HotChocolate;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;
using HotChocolate.Types;
using MassTransit.SqlTransport.Topology;
using Modules.Chats.Application.Common.Models;

namespace Modules.Chats.Endpoints.GraphQL.Subscriptions;

public class ChatSubscriptions
{
    [SubscribeAndResolve]
    [Topic("Chat_{chatId}")]
    public ValueTask<ISourceStream<MessagePayload>> OnMessageSend(
        Guid chatId,
        [Service] ITopicEventReceiver eventReceiver,
        CancellationToken cancellationToken)
    {
        return eventReceiver.SubscribeAsync<MessagePayload>($"Chat_{chatId}", cancellationToken);
    }
}