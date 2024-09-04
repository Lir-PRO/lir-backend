using AutoMapper;
using Common;
using MediatR;
using Modules.Chats.Application.Common.Errors;
using Modules.Chats.Application.Common.Models;
using Modules.Chats.Domain.Entities;
using Modules.Chats.Domain.Interfaces;

namespace Modules.Chats.Application.Messages.Commands.AddMessage;

public class AddMessageCommandHandler(IMessageRepository messageRepository, IMapper mapper)
    : IRequestHandler<AddMessageCommand, Response<MessagePayload>>
{
    public async Task<Response<MessagePayload>> Handle(AddMessageCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.MessageInput.Content))
        {
            return Response<MessagePayload>.Failure(MessageErrors.EmptyMessage);
        }

        var message = new Message { 
            ChatId = request.MessageInput.ChatId,
            UserId = request.MessageInput.SenderId,
            Content = request.MessageInput.Content
        };

        await messageRepository.AddAsync(message);
        var payload = mapper.Map<MessagePayload>(message);

        return Response<MessagePayload>.Success(payload);
    }
}