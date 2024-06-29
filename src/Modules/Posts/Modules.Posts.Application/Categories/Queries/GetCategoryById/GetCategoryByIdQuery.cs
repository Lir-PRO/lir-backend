using MediatR;
using Modules.Posts.Application.Common.Models;

namespace Modules.Posts.Application.Categories.Queries.GetCategoryById
{
    public record GetCategoryByIdQuery(Guid Id) : IRequest<CategoryPayload>;
}
