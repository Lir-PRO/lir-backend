using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Modules.Users.Domain.Common;

namespace Modules.Users.Domain.Entities;

public class Badge : IEntityBase
{
    public Guid Id { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }

    // Navigation properties
    public ICollection<UserBadge> UserBadges { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime CreatedAt { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime UpdatedAt { get; set; }
}