﻿using Modules.Posts.Domain.Entities;

namespace Modules.Posts.Domain.Interfaces
{
    public interface IPostRepository : IEntityBaseRepository<Post>
    {
        Task<IEnumerable<Post>> GetPostsByUserIdAsync(string userId);
        Task<IEnumerable<Post>> GetPostsByCategoryIdAsync(Guid categoryId);
        Task<Post> GetPostByIdAsync(Guid postId);
    }
}
