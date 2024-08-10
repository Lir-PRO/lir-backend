using AutoMapper;
using MediatR;
using Modules.Posts.Application.Common;
using Modules.Posts.Application.Common.Interfaces;
using Modules.Posts.Application.Common.Models;

namespace Modules.Posts.Application.Posts.Queries.GetPostsByUserId
{
    public class GetPostsByUserIdQueryHandler : IRequestHandler<GetPostsByUserIdQuery, Response<IQueryable<PostPayload>>>
    {
        private readonly IPostContext _context;
        private readonly IMapper _mapper;

        public GetPostsByUserIdQueryHandler(IPostContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Task<Response<IQueryable<PostPayload>>> Handle(GetPostsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var posts = _context.Posts.Where(p => p.UserId == request.UserId)
                .AsQueryable();

            var payload = _mapper.Map<IQueryable<PostPayload>>(posts);

            return Task.FromResult(Response<IQueryable<PostPayload>>.Success(payload));
        }
    }
}
