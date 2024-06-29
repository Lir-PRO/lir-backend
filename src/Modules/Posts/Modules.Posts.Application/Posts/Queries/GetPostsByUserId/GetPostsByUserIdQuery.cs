using MediatR;
using Modules.Posts.Application.Common.Models;

namespace Modules.Posts.Application.Posts.Queries.GetPostsByUserId
{
    public record GetPostsByUserIdQuery(string UserId) : IRequest<IQueryable<PostPayload>>;
}