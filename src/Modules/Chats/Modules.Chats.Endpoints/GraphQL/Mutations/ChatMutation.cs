using Common;
using HotChocolate;
using MediatR;
using Modules.Chats.Application.Chats.Commands.AddChat;

namespace Modules.Chats.Endpoints.GraphQL.Mutations;

public class ChatMutation
{
    public async Task<Response<Guid>> AddChat(List<string> participantsIds, [Service] ISender mediatr)
    {
        return await mediatr.Send(new AddChatCommand(participantsIds));
    }
}