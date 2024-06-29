using Modules.Posts.Domain.Entities;
using Modules.Posts.Domain.Enums;

namespace Modules.Posts.Domain.Interfaces
{
    public interface IContentService : IEntityBaseRepository<Content>
    {
        Task<IEnumerable<Content>> GetContentsByContentTypeAsync(ContentType contentType);
        Task<IEnumerable<Content>> GetContentsByPostIdAsync(Guid postId);
    }
}
