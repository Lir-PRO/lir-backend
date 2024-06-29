using System.ComponentModel.DataAnnotations.Schema;

namespace Modules.Posts.Domain.Entities;

public class User
{
    public string Id { get; set; }

    public ICollection<Post> Posts { get; set; }
}