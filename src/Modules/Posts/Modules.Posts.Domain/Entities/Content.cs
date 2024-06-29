using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Modules.Posts.Domain.Common;
using Modules.Posts.Domain.Enums;

namespace Modules.Posts.Domain.Entities;

public class Content : IEntityBase
{
    [Key]
    public Guid Id { get; set; }
    public ContentType ContentType { get; set; }
    public string Base64 { get; set; }

    // Foreign keys
    public Guid PostId { get; set; }

    // Navigation properties
    public Post Post { get; set; }

    //Timestemps
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime CreatedAt { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime UpdatedAt { get; set; }
}