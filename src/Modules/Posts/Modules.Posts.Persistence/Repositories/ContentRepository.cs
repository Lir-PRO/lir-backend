﻿using Microsoft.EntityFrameworkCore;
using Modules.Posts.Domain.Entities;
using Modules.Posts.Domain.Enums;
using Modules.Posts.Domain.Interfaces;

namespace Modules.Posts.Persistence.Repositories
{
    public class ContentRepository : EntityBaseRepository<Content>, IContentRepository
    {
        private readonly PostContext _context;
        public ContentRepository(PostContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Content>> GetContentsByContentTypeAsync(ContentType contentType)
        {
            return await _context.Contents.Where(c => c.ContentType == contentType).ToListAsync();
        }

        public async Task<IEnumerable<Content>> GetContentsByPostIdAsync(Guid postId)
        {
            return await _context.Contents.Where(c => c.PostId == postId).ToListAsync();
        }
    }
}
