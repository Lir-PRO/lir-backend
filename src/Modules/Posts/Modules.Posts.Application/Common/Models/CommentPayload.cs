using AutoMapper;
using Modules.Posts.Application.Common.Mapping;
using Modules.Posts.Domain.Entities;

namespace Modules.Posts.Application.Common.Models;

public class CommentPayload : IMapFrom<Comment>
{
    public Guid Id { get; set; }
    public string Content { get; set; }
    public string UserId { get; set; }
    public Guid PostId { get; set; }
    public DateTime CreatedAt { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Comment, CommentPayload>();
    }
}