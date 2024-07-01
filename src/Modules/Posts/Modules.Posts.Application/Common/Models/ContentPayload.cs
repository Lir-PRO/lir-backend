using AutoMapper;
using Modules.Posts.Application.Common.Mapping;
using Modules.Posts.Domain.Entities;
using Modules.Posts.Domain.Enums;

namespace Modules.Posts.Application.Common.Models;

public class ContentPayload : IMapFrom<Content>
{
    public Guid Id { get; set; }
    public string Base64 { get; set; }
    public ContentType ContentType { get; set; }
    public Guid PostId { get; set; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Content, ContentPayload>();
    }
}