using Common;
using MediatR;
using Modules.Chats.Application.Common.Errors;
using Modules.Chats.Domain.Entities;
using Modules.Chats.Domain.Interfaces;

namespace Modules.Chats.Application.Messages.Commands.AddMessage;

public class AddMessageCommandHandler : IRequestHandler<AddMessageCommand, Response<string>>
{
    private readonly IMessageRepository _messageRepository;

    public AddMessageCommandHandler(IMessageRepository messageRepository)
    {
        _messageRepository = messageRepository;
    }

    public async Task<Response<string>> Handle(AddMessageCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.MessageInput.Content))
        {
            return Response<string>.Failure(MessageErrors.EmptyMessage);
        }

        var message = new Message { 
            ChatId = request.MessageInput.ChatId,
            UserId = request.MessageInput.SenderId,
            Content = request.MessageInput.Content
        };

        await _messageRepository.AddAsync(message);
        return Response<string>.Success(request.MessageInput.Content);
    }
}