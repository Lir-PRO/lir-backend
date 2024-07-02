using Modules.Posts.Application.Common.InputTypes;
using MediatR;
using Modules.Posts.Application.Common.Models;

namespace Modules.Posts.Application.Categories.Commands.UpdateCategory;

public record UpdateCategoryCommand(UpdateCategoryInput Input) : IRequest<CategoryPayload>;