using HotChocolate;
using MediatR;
using Modules.Posts.Application.Categories.Commands.AddCategory;
using Modules.Posts.Application.Common.Models;

namespace Modules.Posts.Endpoints.GraphQL.Mutations;

public class CategoryMutation
{
    public async Task<CategoryPayload> AddCategory(string name, string description, [Service] ISender mediatr)
    {
        return await mediatr.Send(new AddCategoryCommand(name, description));
    }
}