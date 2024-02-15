
namespace Lir.Core.Models
{
    public class Chat : BaseEntity
    {
        // Navigation properties
        public ICollection<Message> Messages { get; set; }
        public ICollection<UserChat> UserChats { get; set; }
    }
}
