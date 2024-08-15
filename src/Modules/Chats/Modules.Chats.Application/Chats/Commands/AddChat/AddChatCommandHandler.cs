using Common;
using MediatR;
using Modules.Chats.Application.Common.Errors;
using Modules.Chats.Domain.Interfaces;

namespace Modules.Chats.Application.Chats.Commands.AddChat;

public class AddChatCommandHandler : IRequestHandler<AddChatCommand, Response<Guid>>
{
    private readonly IChatRepository _chatRepository;
    private readonly IUserRepository _userRepository;

    public AddChatCommandHandler(IChatRepository chatRepository, IUserRepository userRepository)
    {
        _chatRepository = chatRepository;
        _userRepository = userRepository;
    }

    public async Task<Response<Guid>> Handle(AddChatCommand request, CancellationToken cancellationToken)
    {
        foreach (var participantId in request.ParticipantsIds)
        {
            if (!await _userRepository.UserExists(participantId))
            {
                return Response<Guid>.Failure(ChatErrors.UserNotFound);
            }
        }

        var chatId = await _chatRepository.AddAsync(request.ParticipantsIds);

        return Response<Guid>.Success(chatId);
    }
}