using MediatR;
using Modules.Posts.Application.Common.Models;

namespace Modules.Posts.Application.Categories.Queries.GetCategoriesByPostId;

public record GetCategoriesByPostIdQuery(Guid PostId) : IRequest<IQueryable<CategoryPayload>>;