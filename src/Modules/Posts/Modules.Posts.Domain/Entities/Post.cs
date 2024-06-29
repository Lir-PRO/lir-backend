using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Modules.Posts.Domain.Common;

namespace Modules.Posts.Domain.Entities;

public class Post : IEntityBase
{
    [Key]
    public Guid Id { get; set; }
    public string Caption { get; set; }
    public int Likes { get; set; } = 0;
    public int Views { get; set; } = 0;

    // Foreign keys
    public string UserId { get; set; }

    // Navigation properties
    public User User { get; set; }
    public ICollection<Comment> Comments { get; set; }
    public ICollection<Content> Contents { get; set; }
    public ICollection<PostCategory> PostCategories { get; set; }

    //Timestemps
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime CreatedAt { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime UpdatedAt { get; set; }
}