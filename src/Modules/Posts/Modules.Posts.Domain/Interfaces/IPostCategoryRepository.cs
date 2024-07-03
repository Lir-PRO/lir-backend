using Modules.Posts.Domain.Entities;

namespace Modules.Posts.Domain.Interfaces
{
    public interface IPostCategoryRepository
    {
        Task<PostCategory> AddAsync(PostCategory postCategory);

        Task<ICollection<PostCategory>> GetByPostId(Guid id);

        void Delete(PostCategory postCategory);
    }
}
