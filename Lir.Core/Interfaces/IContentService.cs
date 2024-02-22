using Lir.Core.Enums;
using Lir.Core.Models;
using Lir.Core.Models.Interfaces;

namespace Lir.Core.Interfaces
{
    public interface IContentService : IEntityBaseRepository<Content>
    {
        Task<IEnumerable<Content>> GetContentsByContentTypeAsync(ContentType contentType);
        Task<IEnumerable<Content>> GetContentsByPostIdAsync(Guid postId);
    }
}
