using AutoMapper;
using MediatR;
using Modules.Posts.Application.Common.Interfaces;
using Modules.Posts.Application.Common.Models;

namespace Modules.Posts.Application.Posts.Queries.GetPostsByCategoryId
{
    public class GetPostsByCategoryIdQueryHandler : IRequestHandler<GetPostsByCategoryIdQuery, IQueryable<PostPayload>>
    {
        private readonly IPostContext _context;
        private readonly IMapper _mapper;

        public GetPostsByCategoryIdQueryHandler(IPostContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Task<IQueryable<PostPayload>> Handle(GetPostsByCategoryIdQuery request, CancellationToken cancellationToken)
        {
            var posts = _context.PostCategories.Where(pc => pc.Category.Id == request.CategoryId)
                .Select(pc => pc.Post).AsQueryable(); ;

            return Task.FromResult(_mapper.Map<IQueryable<PostPayload>>(posts));
        }
    }
}
