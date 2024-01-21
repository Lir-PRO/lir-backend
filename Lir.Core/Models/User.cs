
namespace Lir.Core.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public string ProfilePictureBase64 { get; set; }

        // Navigation properties
        public ICollection<Post> Posts { get; set; }
        public ICollection<UserBadge> UserBadges { get; set; }
        public ICollection<UserChat> UserChats { get; set; }
    }
}
