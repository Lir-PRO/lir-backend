using MediatR;

namespace Modules.Posts.Application.Comments.Commands.DeleteComment;

public record DeleteCommentCommand(Guid Id) : IRequest<bool>;