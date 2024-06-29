using AutoMapper;
using Modules.Posts.Application.Common.Mapping;
using Modules.Posts.Domain.Entities;

namespace Modules.Posts.Application.Common.Models
{
    public class PostPayload : IMapFrom<Post>
    {
        public Guid Id { get; set; }
        public string Caption { get; set; }
        public int Likes { get; set; } = 0;
        public int Views { get; set; } = 0;
        public Guid UserId { get; set; }
        public ICollection<PostCategory> PostCategories { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Post, PostPayload>();
        }
    }
}
