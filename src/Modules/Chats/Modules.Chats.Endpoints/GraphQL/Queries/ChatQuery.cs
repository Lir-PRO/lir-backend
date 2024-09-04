using HotChocolate;
using MediatR;
using Modules.Chats.Application.Common.Models;
using Modules.Chats.Application.Chats.Queries.GetChatsByUserId;
using HotChocolate.Types;

namespace Modules.Chats.Endpoints.GraphQL.Queries;

public class ChatQuery
{
    [UsePaging(IncludeTotalCount = true)]
    [UseFiltering]
    [UseSorting]
    public async Task<IQueryable<ChatPayload>> GetChatsByUserId(string userId, [Service] ISender mediatr)
    {
        return await mediatr.Send(new ChatsByUserIdQuery(userId));
    }
}