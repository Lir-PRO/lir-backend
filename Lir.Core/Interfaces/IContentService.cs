using Lir.Core.Enums;
using Lir.Core.Models;
using Lir.Core.Models.Interfaces;

namespace Lir.Core.Interfaces
{
    public interface IContentService : IEntityBaseRepository<Content>
    {
        Task<IQueryable<Content>> GetContentsByContentTypeAsync(ContentType contentType);
        Task<IQueryable<Content>> GetContentsByPostIdAsync(Guid postId);
    }
}
