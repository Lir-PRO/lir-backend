using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lir.Core.Models
{
    public class Post
    {
        public Guid Id { get; set; }
        public string Caption { get; set; }

        // Foreign keys
        public Guid UserId { get; set; }

        // Navigation properties
        public User User { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Content> Contents { get; set; }
        public ICollection<PostCategory> PostCategories { get; set; }
    }
}
