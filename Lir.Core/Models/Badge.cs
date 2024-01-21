
namespace Lir.Core.Models
{
    public class Badge
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // Navigation properties
        public ICollection<UserBadge> UserBadges { get; set; }
    }
}
