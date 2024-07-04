using MediatR;
using Modules.Posts.Application.Common.InputTypes;
using Modules.Posts.Application.Common.Models;

namespace Modules.Posts.Application.Comments.Commands.UpdateComment;

public record UpdateCommentCommand(UpdateCommentInput Input) : IRequest<CommentPayload>;