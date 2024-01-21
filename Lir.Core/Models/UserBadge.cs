
namespace Lir.Core.Models
{
    public class UserBadge
    {
        public Guid UserId { get; set; }
        public Guid BadgeId { get; set; }

        // Navigation properties
        public User User { get; set; }
        public Badge Badge { get; set; }
    }
}
