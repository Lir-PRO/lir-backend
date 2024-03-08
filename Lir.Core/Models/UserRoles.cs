using System.ComponentModel.DataAnnotations;
using Lir.Core.Models.Interfaces;

namespace Lir.Core.Models
{
    public class UserRoles :IEntityBase
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
