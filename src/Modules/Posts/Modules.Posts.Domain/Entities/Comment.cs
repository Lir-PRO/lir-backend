using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Modules.Posts.Domain.Common;

namespace Modules.Posts.Domain.Entities;

public class Comment : IEntityBase
{
    [Key]
    public Guid Id { get; set; }
    public string Content { get; set; }

    // Foreign keys
    public string UserId { get; set; }
    public Guid PostId { get; set; }

    // Navigation properties
    public User User { get; set; }
    public Post Post { get; set; }

    //Timestemps
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime CreatedAt { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime UpdatedAt { get; set; }
}