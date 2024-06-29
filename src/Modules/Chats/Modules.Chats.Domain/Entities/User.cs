using System.ComponentModel.DataAnnotations.Schema;

namespace Modules.Chats.Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public string RefId { get; set; }

    public ICollection<UserChat> UserChats { get; set; }
}