using Lir.Core.Models;

namespace Lir.Core.Interfaces
{
    public interface IPostCategoryService
    {
        Task<PostCategory> AddAsync(PostCategory postCategory);
        void Delete(PostCategory postCategory);
    }
}
