using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lir.Core.Models
{
    public class PostCategory
    {
        public Guid PostId { get; set; }
        public Guid CategoryId { get; set; }

        // Navigation properties
        public Post Post { get; set; }
        public Category Category { get; set; }
    }
}
