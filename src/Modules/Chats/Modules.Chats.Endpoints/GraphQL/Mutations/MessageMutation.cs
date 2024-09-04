using Common;
using HotChocolate;
using HotChocolate.Subscriptions;
using MediatR;
using Modules.Chats.Application.Common.Models;
using Modules.Chats.Application.Messages.Commands.AddMessage;

namespace Modules.Chats.Endpoints.GraphQL.Mutations;

public class MessageMutation
{
    public async Task<Response<MessagePayload>> AddMessage(
        AddMessageInput input,
        [Service] ISender mediatr,
        [Service] ITopicEventSender eventSender,
        CancellationToken cancellationToken)
    {
        var result = await mediatr.Send(new AddMessageCommand(input));

        if (result.IsSuccess)
        {
            Console.WriteLine($"Publishing message to Chat_{input.ChatId}");
            await eventSender.SendAsync($"Chat_{input.ChatId}", result.Data, cancellationToken);
        }

        return result;
    }
    
}