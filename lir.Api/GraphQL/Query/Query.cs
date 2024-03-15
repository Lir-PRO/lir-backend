using Lir.Core.Models;
using Lir.Infrastructure.Persistence;

namespace Lir.Api.GraphQL.Query
{
    public class Query
    {
        [UseDbContext(typeof(LirDbContext))]
        [UsePaging(IncludeTotalCount = true)]
        public IQueryable<Comment> GetCommentsByPostId(Guid postId, [Service] LirDbContext context)
        {
            var comments = context.Comments.Where(c => c.PostId == postId);
            return comments;
        }
    }
}
