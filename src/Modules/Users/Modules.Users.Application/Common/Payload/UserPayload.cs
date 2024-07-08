using AutoMapper;
using Modules.Users.Application.Common.Mapping;
using Modules.Users.Domain.Entities;

namespace Modules.Users.Application.Common.Payload;

public class UserPayload : IMapFrom<User>
{
    public string Id { get; set; }
    public string Username { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Bio { get; set; }
    public string ProfilePictureBase64 { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<User, UserPayload>();
    }
}