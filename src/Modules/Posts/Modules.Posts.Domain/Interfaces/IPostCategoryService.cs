using Modules.Posts.Domain.Entities;

namespace Modules.Posts.Domain.Interfaces
{
    public interface IPostCategoryService
    {
        Task<PostCategory> AddAsync(PostCategory postCategory);
        void Delete(PostCategory postCategory);
    }
}
