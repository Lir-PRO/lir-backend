using Lir.Core.Enums;

namespace Lir.Core.Models
{
    public class Content : BaseEntity
    {
        public ContentType ContentType { get; set; }
        public string ContentBase64 { get; set; }

        // Foreign keys
        public Guid PostId { get; set; }

        // Navigation properties
        public Post Post { get; set; }
    }
}
