using Modules.Posts.Domain.Entities;

namespace Modules.Posts.Domain.Interfaces
{
    public interface IPostCategoryRepository
    {
        Task<PostCategory> AddAsync(PostCategory postCategory);
        void Delete(PostCategory postCategory);
    }
}
