using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Lir.Core.Models.Interfaces;

namespace Lir.Core.Models
{
    public class Chat : IEntityBase
    {
        [Key]
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
