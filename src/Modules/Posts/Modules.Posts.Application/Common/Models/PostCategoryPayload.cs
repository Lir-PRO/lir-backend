using AutoMapper;
using Modules.Posts.Domain.Entities;

namespace Modules.Posts.Application.Common.Models
{
    public class PostCategoryPayload
    {
        public Guid PostId { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PostCategory, PostCategoryPayload>();
        }
    }
}
