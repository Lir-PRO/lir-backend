using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Modules.Chats.Domain.Common;

namespace Modules.Chats.Domain.Entities
{
    public class Chat : IEntityBase
    {
        public Guid Id { get; set; }

        // Navigation properties
        public ICollection<Message> Messages { get; set; }
        public ICollection<UserChat> UserChats { get; set; }

        //Timestamps
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedAt { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedAt { get; set; }
    }
}
