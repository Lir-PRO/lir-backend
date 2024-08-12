using Common;
using MediatR;
using Modules.Posts.Application.Common;

namespace Modules.Posts.Application.Comments.Commands.DeleteComment;

public record DeleteCommentCommand(Guid Id) : IRequest<Response<bool>>;