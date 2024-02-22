using Lir.Core.Enums;
using Lir.Core.Interfaces;
using Lir.Core.Models;
using Lir.Infrastructure.Persistence;
using Lir.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Lir.Infrastructure.Services
{
    public class ContentService : EntityBaseRepository<Content>, IContentService
    {
        private readonly LirDbContext _context;
        public ContentService(LirDbContext context) : base(context)
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
