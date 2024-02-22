using Lir.Core.Models;
using Lir.Core.Models.Interfaces;

namespace Lir.Core.Interfaces
{
    public interface IPostService : IEntityBaseRepository<Post>
    {
        Task<IEnumerable<Post>> GetPostsByUserIdAsync(Guid userId);
        Task<IEnumerable<Post>> GetPostsByCategoryIdAsync(Guid categoryId);
    }
}
