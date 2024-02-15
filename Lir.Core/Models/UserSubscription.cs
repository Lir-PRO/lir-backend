
namespace Lir.Core.Models
{
    public class UserSubscription
    {
        public Guid UserId { get; set; }
        public Guid SubscriberId { get; set; }

        // Navigation properties
        public User User { get; set; }
        public User Subscriber { get; set; }
    }
}
