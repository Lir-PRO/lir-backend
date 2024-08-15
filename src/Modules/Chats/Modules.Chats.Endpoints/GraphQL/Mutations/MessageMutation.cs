using Common;
using HotChocolate;
using MediatR;
using Modules.Chats.Application.Common.Models;
using Modules.Chats.Application.Messages.Commands.AddMessage;

namespace Modules.Chats.Endpoints.GraphQL.Mutations;

public class MessageMutation
{
    public async Task<Response<string>> AddMessage(AddMessageInput input, [Service] ISender mediatr)
    {
        return await mediatr.Send(new AddMessageCommand(input));
    }
}