using MediatR;
using Modules.Chats.Application.Common.Models;

namespace Modules.Chats.Application.Chats.Queries.GetChatsByUserId;

public record ChatsByUserIdQuery(string UserId) : IRequest<IQueryable<ChatPayload>>;