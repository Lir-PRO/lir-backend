using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lir.Core.Models
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string Content { get; set; }

        // Foreign keys
        public Guid UserId { get; set; }
        public Guid PostId { get; set; }

        // Navigation properties
        public User User { get; set; }
        public Post Post { get; set; }
    }
}
