using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Lir.Core.Models.Interfaces;

namespace Lir.Core.Models
{
    public class Post : IEntityBase
    {
        [Key]
        public Guid Id { get; set; }
        public string Caption { get; set; }
        public int Likes { get; set; } = 0;
        public int Views { get; set; } = 0;

        // Foreign keys
        public Guid UserId { get; set; }

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
}
