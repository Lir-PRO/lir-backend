using HotChocolate;
using HotChocolate.Types;
using MediatR;
using Modules.Posts.Application.Comments.Queries.GetCommentsByPostId;
using Modules.Posts.Application.Common;
using Modules.Posts.Application.Common.Models;

namespace Modules.Posts.Endpoints.GraphQL.Queries;
public class CommentQuery
{
    [UsePaging(IncludeTotalCount = true)]
    [UseFiltering]
    [UseSorting]
    public async Task<Response<IQueryable<CommentPayload>>> GetCommentsByPostId(Guid postId, [Service] ISender mediatr)
    {
        return await mediatr.Send(new GetCommentsByPostIdQuery(postId));
    }
}