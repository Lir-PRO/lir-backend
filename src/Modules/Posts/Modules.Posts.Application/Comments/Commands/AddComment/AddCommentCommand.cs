using MediatR;
using Modules.Posts.Application.Common.InputTypes;
using Modules.Posts.Application.Common.Models;

namespace Modules.Posts.Application.Comments.Commands.AddComment;

public record AddCommentCommand(AddCommentInput Input) : IRequest<CommentPayload>;