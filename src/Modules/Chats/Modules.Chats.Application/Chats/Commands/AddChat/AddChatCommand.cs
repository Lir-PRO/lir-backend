using Common;
using MediatR;

namespace Modules.Chats.Application.Chats.Commands.AddChat;

public record AddChatCommand(List<string> ParticipantsIds) : IRequest<Response<Guid>>;