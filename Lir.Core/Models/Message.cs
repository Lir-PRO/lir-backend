using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Lir.Core.Models.Interfaces;

namespace Lir.Core.Models
{
    public class Message : IEntityBase   
    {
        [Key]
        public Guid Id { get; set; }
        public string Content { get; set; }

        // Foreign keys
        public Guid UserId { get; set; }
        public Guid ChatId { get; set; }

        // Navigation properties
        public User User { get; set; }
        public Chat Chat { get; set; }

        //Timestemps
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedAt { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedAt { get; set; }
    }
}
