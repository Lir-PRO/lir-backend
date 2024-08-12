using MediatR;
using Modules.Posts.Application.Common;
using Modules.Posts.Application.Common.Models;

namespace Modules.Posts.Application.Comments.Queries.GetCommentsByPostId;

public record GetCommentsByPostIdQuery(Guid PostId) : IRequest<IQueryable<CommentPayload>>;