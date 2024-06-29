namespace Modules.Users.Domain.Entities;

public class UserBadge
{
    public string UserId { get; set; }
    public Guid BadgeId { get; set; }

    // Navigation properties
    public User User { get; set; }
    public Badge Badge { get; set; }
}