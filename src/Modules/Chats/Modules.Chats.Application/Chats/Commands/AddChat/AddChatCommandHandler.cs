using Common;
using MediatR;
using Modules.Chats.Application.Common.Errors;
using Modules.Chats.Domain.Interfaces;

namespace Modules.Chats.Application.Chats.Commands.AddChat;

public class AddChatCommandHandler(IChatRepository chatRepository, IUserRepository userRepository)
    : IRequestHandler<AddChatCommand, Response<Guid>>
{
    public async Task<Response<Guid>> Handle(AddChatCommand request, CancellationToken cancellationToken)
    {
        foreach (var participantId in request.ParticipantsIds)
        {
            if (!await userRepository.UserExists(participantId))
            {
                return Response<Guid>.Failure(ChatErrors.UserNotFound);
            }
        }

        var chatId = await chatRepository.AddAsync(request.ParticipantsIds);

        return Response<Guid>.Success(chatId);
    }
}