using AutoMapper;
using Modules.Posts.Domain.Entities;

namespace Modules.Posts.Application.Common.Models
{
    public class CategoryPayload
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<PostCategory> PostCategories { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Category, CategoryPayload>();
        }
    }
}
