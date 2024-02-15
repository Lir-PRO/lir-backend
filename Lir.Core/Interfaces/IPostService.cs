using Lir.Core.Models;
using Lir.Core.Models.Interfaces;

namespace Lir.Core.Interfaces
{
    public interface IPostService : IEntityBaseRepository<Badge>
    {
        Task<IQueryable<Post>> GetPostsByUserIdAsync(Guid userId);
        Task<IQueryable<Post>> GetPostsByCategoryIdAsync(Guid categoryId);
    }
}
