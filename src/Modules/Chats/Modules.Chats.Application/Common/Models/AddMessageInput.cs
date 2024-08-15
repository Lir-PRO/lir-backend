
namespace Modules.Chats.Application.Common.Models;

public class AddMessageInput
{
    public string Content { get; set; }
    public Guid ChatId { get; set; }
    public string SenderId { get; set; }
}