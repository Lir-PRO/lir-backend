namespace Modules.Posts.Application.Common.InputTypes;

public class UpdateCategoryInput
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }
}