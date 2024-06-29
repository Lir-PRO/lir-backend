using HotChocolate;
using HotChocolate.Types;
using MediatR;
using Modules.Posts.Application.Categories.Queries.GetCategoryById;
using Modules.Posts.Application.Common.Models;

namespace Modules.Posts.Endpoints.GraphQL.Queries;

public class CategoryQuery
{
    public async Task<CategoryPayload> GetCategoryById(Guid id, [Service] ISender mediatr)
    {
        return await mediatr.Send(new GetCategoryByIdQuery(id));
    }
}