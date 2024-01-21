using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Lir.Core.Models
{
    public class Content
    {
        public Guid Id { get; set; }
        public ContentType ContentType { get; set; }
        public string ContentBase64 { get; set; }

        // Foreign keys
        public Guid PostId { get; set; }

        // Navigation properties
        public Post Post { get; set; }
    }
}
