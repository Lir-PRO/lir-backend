using AutoMapper;
using MediatR;
using Modules.Chats.Application.Common.Models;
using Modules.Chats.Domain.Interfaces;

namespace Modules.Chats.Application.Chats.Queries.GetChatsByUserId;

public class ChatsByUserIdQueryHandler(IChatRepository chatRepository, IMapper mapper)
    : IRequestHandler<ChatsByUserIdQuery, IQueryable<ChatPayload>>
{

    public async Task<IQueryable<ChatPayload>> Handle(ChatsByUserIdQuery request, CancellationToken cancellationToken)
    {
        var chats = await chatRepository.GetChatsByUserIdAsync(request.UserId);
        var payload =  mapper.Map<List<ChatPayload>>(chats);

        return payload.AsQueryable();
    }
}