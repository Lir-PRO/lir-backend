using MediatR;
using Modules.Posts.Application.Common.Models;

namespace Modules.Posts.Application.Posts.Queries.GetPostsByCategoryId
{
    public record GetPostsByCategoryIdQuery(Guid CategoryId) : IRequest<IQueryable<PostPayload>>;
}