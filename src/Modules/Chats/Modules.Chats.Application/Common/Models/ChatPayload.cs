using AutoMapper;
using Modules.Chats.Application.Common.Mapping;
using Modules.Chats.Domain.Entities;

namespace Modules.Chats.Application.Common.Models;

public class ChatPayload : IMapFrom<Chat>
{
    public Guid Id { get; set; }

    // Navigation properties
    public ICollection<MessagePayload> Messages { get; set; }
    public ICollection<string> ParticipantsIds { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Chat, ChatPayload>()
            .ForMember(cp => cp.ParticipantsIds, m 
                => m.MapFrom(u => u.UserChats.Select(uc => uc.UserId)));
    }
}