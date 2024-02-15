using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Lir.Core.Models.Interfaces;

namespace Lir.Core.Models
{
    public class Comment : IEntityBase
    {
        [Key]
        public Guid Id { get; set; }
        public string Content { get; set; }

        // Foreign keys
        public Guid UserId { get; set; }
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
}
