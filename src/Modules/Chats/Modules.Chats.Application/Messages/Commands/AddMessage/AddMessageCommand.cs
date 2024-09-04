using Common;
using MediatR;
using Modules.Chats.Application.Common.Models;

namespace Modules.Chats.Application.Messages.Commands.AddMessage;

public record AddMessageCommand(AddMessageInput MessageInput) : IRequest<Response<MessagePayload>>;