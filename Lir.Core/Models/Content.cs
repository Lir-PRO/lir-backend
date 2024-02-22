using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Lir.Core.Enums;
using Lir.Core.Models.Interfaces;

namespace Lir.Core.Models
{
    public class Content : IEntityBase
    {
        [Key]
        public Guid Id { get; set; }
        public ContentType ContentType { get; set; }
        public string ContentBase64 { get; set; }

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
}
