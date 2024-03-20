using Lir.Core.Models;

namespace Lir.Core.Interfaces
{
    public interface IPostService : IEntityBaseRepository<Post>
    {
        Task<IEnumerable<Post>> GetPostsByUserIdAsync(Guid userId);
        Task<IEnumerable<Post>> GetPostsByCategoryIdAsync(Guid categoryId);
        Task<Post> GetPostByIdAsync(Guid postId);
    }
}
