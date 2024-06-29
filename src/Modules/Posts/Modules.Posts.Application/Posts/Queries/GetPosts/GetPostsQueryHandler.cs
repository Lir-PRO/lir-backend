using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Modules.Posts.Application.Common.Interfaces;
using Modules.Posts.Application.Common.Models;

namespace Modules.Posts.Application.Posts.Queries.GetPosts
{
    public class GetPostsQueryHandler : IRequestHandler<GetPostsQuery, IQueryable<PostPayload>>
    {
        private readonly IPostContext _context;
        private readonly IMapper _mapper;

        public GetPostsQueryHandler(IPostContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<IQueryable<PostPayload>> Handle(GetPostsQuery request, CancellationToken cancellationToken)
        {
            var posts = _context.Posts.Include(p => p.PostCategories)
                .ThenInclude(pc => pc.Category).AsQueryable();

            return Task.FromResult(_mapper.Map<IQueryable<PostPayload>>(posts));
        }
    }
}
