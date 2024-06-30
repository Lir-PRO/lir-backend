using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Modules.Chats.Domain.Common;

namespace Modules.Chats.Domain.Entities
{
    public class Message : IEntityBase
    {
        [Key]
        public Guid Id { get; set; }
        public string Content { get; set; }

        // Foreign keys
        public string UserId { get; set; }
        public Guid ChatId { get; set; }

        // Navigation properties
        public Chat Chat { get; set; }

        //Timestemps
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedAt { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedAt { get; set; }
    }
}
