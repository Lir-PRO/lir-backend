﻿namespace Modules.Chats.Domain.Entities;
public class UserChat
{
    public Guid UserId { get; set; }
    public Guid ChatId { get; set; }

    // Navigation properties
    public User User { get; set; }
    public Chat Chat { get; set; }
}