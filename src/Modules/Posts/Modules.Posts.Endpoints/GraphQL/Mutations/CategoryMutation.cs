using HotChocolate;
using MediatR;
using Modules.Posts.Application.Categories.Commands.AddCategory;
using Modules.Posts.Application.Categories.Commands.DeleteCategory;
using Modules.Posts.Application.Categories.Commands.UpdateCategory;
using Modules.Posts.Application.Common.InputTypes;
using Modules.Posts.Application.Common.Models;

namespace Modules.Posts.Endpoints.GraphQL.Mutations;

public class CategoryMutation
{
    public async Task<CategoryPayload> AddCategory(string name, string description, [Service] ISender mediatr)
    {
        return await mediatr.Send(new AddCategoryCommand(name, description));
    }

    public async Task<CategoryPayload> UpdateCategory(UpdateCategoryInput input, [Service] ISender mediatr)
    {
        return await mediatr.Send(new UpdateCategoryCommand(input));
    }

    public async Task<bool> DeleteCategory(Guid id, [Service] ISender mediatr)
    {
        return await mediatr.Send(new DeleteCategoryCommand(id));
    }
}