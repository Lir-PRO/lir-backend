namespace Modules.Users.Domain.Entities;

public class UserSubscription
{
    public string UserId { get; set; }
    public string SubscriberId { get; set; }

    // Navigation properties
    public User User { get; set; }
    public User Subscriber { get; set; }
}