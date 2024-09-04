using AutoMapper;
using Modules.Chats.Application.Common.Mapping;
using Modules.Chats.Domain.Entities;

namespace Modules.Chats.Application.Common.Models;

public class MessagePayload : IMapFrom<Chat>
{
    public Guid Id { get; set; }
    public string Content { get; set; }

    // Foreign keys
    public string UserId { get; set; }
    public Guid ChatId { get; set; }
    //Timestemps
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Message, MessagePayload>();
    }
}