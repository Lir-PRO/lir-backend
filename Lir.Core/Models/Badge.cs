
namespace Lir.Core.Models
{
    public class Badge : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        // Navigation properties
        public ICollection<UserBadge> UserBadges { get; set; }
    }
}
