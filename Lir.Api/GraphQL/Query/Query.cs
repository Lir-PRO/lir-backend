using Lir.Core.Models;
using Lir.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Lir.Api.GraphQL.Query
{
    public class Query
    {
        [UseDbContext(typeof(LirDbContext))]
        [UsePaging(IncludeTotalCount = true)]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Comment> GetCommentsByPostId(Guid postId, [Service] LirDbContext context)
        {
            return context.Comments.Where(c => c.PostId == postId);
        }

        [UseDbContext(typeof(LirDbContext))]
        [UsePaging(IncludeTotalCount = true)]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Post> GetPosts([Service] LirDbContext context )
        {
            return context.Posts.Include(p => p.PostCategories)
                .ThenInclude(pc => pc.Category).AsQueryable();
        }

        [UseDbContext(typeof(LirDbContext))]
        [UsePaging(IncludeTotalCount = true)]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Category> GetCategories([Service] LirDbContext context)
        {
            return context.Categories.Include(c => c.PostCategories)
                .ThenInclude(p => p.Category).AsQueryable();
        }

        [UseDbContext(typeof(LirDbContext))]
        [UsePaging(IncludeTotalCount = true)]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Post> GetPostsByCategoryId(Guid categoryId, [Service] LirDbContext context)
        {
            return context.PostCategories.Where(pc => pc.Category.Id == categoryId)
                .Select(pc => pc.Post).AsQueryable();
        }

        [UseDbContext(typeof(LirDbContext))]
        [UsePaging(IncludeTotalCount = true)]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Post> GetPostsByUserId(Guid userId, [Service] LirDbContext context)
        {
            return context.Posts.Where(p => p.UserId == userId)
                .AsQueryable();
        }
    }
}
