using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lir.Core.Models
{
    public class User : IdentityUser<Guid>
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public string ProfilePictureBase64 { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedAt { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedAt { get; set; }

        // Navigation properties
        public ICollection<Post> Posts { get; set; }
        public ICollection<Message> Messages { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public List<UserSubscription> Subscriptions { get; set; }
        public List<UserSubscription> Subscribers { get; set; }
        public ICollection<UserBadge> UserBadges { get; set; }
        public ICollection<UserChat> UserChats { get; set; }
    }
}
