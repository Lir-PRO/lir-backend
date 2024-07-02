using MediatR;
using Modules.Posts.Application.Common.Models;

namespace Modules.Posts.Application.Categories.Commands.AddCategory;

public record AddCategoryCommand(string Name, string Description) : IRequest<CategoryPayload>;