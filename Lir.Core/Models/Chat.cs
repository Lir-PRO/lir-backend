
namespace Lir.Core.Models
{
    public class Chat
    {
        public Guid Id { get; set; }

        // Navigation properties
        public ICollection<Message> Messages { get; set; }
        public ICollection<UserChat> UserChats { get; set; }
    }
}
