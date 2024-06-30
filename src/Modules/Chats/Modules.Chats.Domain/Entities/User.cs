using System.ComponentModel.DataAnnotations.Schema;

namespace Modules.Chats.Domain.Entities;

public class User
{
    public string Id { get; set; }

    public ICollection<UserChat> UserChats { get; set; }
}