using MediatR;
using Modules.Posts.Application.Common.Models;

namespace Modules.Posts.Application.Posts.Queries.GetPosts
{
    public record GetPostsQuery : IRequest<IQueryable<PostPayload>>;
}