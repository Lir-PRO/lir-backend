using System.ComponentModel.DataAnnotations.Schema;
using Modules.Users.Domain.Common;

namespace Modules.Users.Domain.Entities;

public class User
{
    public  string Id { get; set; }
    public string Username { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Bio { get; set; }
    public string ProfilePictureBase64 { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime CreatedAt { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime UpdatedAt { get; set; }

    // Navigation properties
    public List<UserSubscription> Subscriptions { get; set; }
    public List<UserSubscription> Subscribers { get; set; }
    public ICollection<UserBadge> UserBadges { get; set; }
}