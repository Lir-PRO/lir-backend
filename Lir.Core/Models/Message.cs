using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lir.Core.Models
{
    public class Message : BaseEntity
    {
        public string Content { get; set; }

        // Foreign keys
        public Guid UserId { get; set; }
        public Guid ChatId { get; set; }

        // Navigation properties
        public User User { get; set; }
        public Chat Chat { get; set; }
    }
}
