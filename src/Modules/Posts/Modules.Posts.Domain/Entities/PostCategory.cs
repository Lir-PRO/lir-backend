namespace Modules.Posts.Domain.Entities;

public class PostCategory
{
    public Guid PostId { get; set; }
    public Guid CategoryId { get; set; }

    // Navigation properties
    public Post Post { get; set; }
    public Category Category { get; set; }
}