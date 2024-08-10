using HotChocolate;
using HotChocolate.Types;
using MediatR;
using Modules.Posts.Application.Common;
using Modules.Posts.Application.Common.Models;
using Modules.Posts.Application.Posts.Queries.GetPosts;
using Modules.Posts.Application.Posts.Queries.GetPostsByCategoryId;
using Modules.Posts.Application.Posts.Queries.GetPostsByUserId;

namespace Modules.Posts.Endpoints.GraphQL.Queries
{
    public class PostQuery
    {
        [UsePaging(IncludeTotalCount = true)]
        [UseFiltering]
        [UseSorting]
        public async Task<Response<IQueryable<PostPayload>>> GetPosts([Service] ISender mediatr)
        {
            return await mediatr.Send(new GetPostsQuery());
        }

        [UsePaging(IncludeTotalCount = true)]
        [UseFiltering]
        [UseSorting]
        public async Task<Response<IQueryable<PostPayload>>> GetPostsByCategoryId(Guid categoryId, [Service] ISender mediatr)
        {
            return await mediatr.Send(new GetPostsByCategoryIdQuery(CategoryId: categoryId));
        }

        [UsePaging(IncludeTotalCount = true)]
        [UseFiltering]
        [UseSorting]
        public async Task<Response<IQueryable<PostPayload>>> GetPostsByUserId(string userId, [Service] ISender mediatr)
        {
            return await mediatr.Send(new GetPostsByUserIdQuery(UserId: userId));
        }
    }
}