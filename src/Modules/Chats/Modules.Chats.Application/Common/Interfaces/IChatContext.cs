using Microsoft.EntityFrameworkCore;
using Modules.Chats.Domain.Entities;

namespace Modules.Chats.Application.Common.Interfaces;

public interface IChatContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Chat> Chats { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<UserChat> UserChats { get; set; }
}