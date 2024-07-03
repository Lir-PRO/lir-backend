using AutoMapper;
using MediatR;
using Modules.Posts.Application.Common.Models;
using Modules.Posts.Domain.Interfaces;

namespace Modules.Posts.Application.Categories.Queries.GetCategoriesByPostId
{
    public class GetCategoriesByPostIdQueryHandler : IRequestHandler<GetCategoriesByPostIdQuery, IQueryable<CategoryPayload>>
    {
        private readonly IPostCategoryRepository _postCategoryRepository;
        private readonly IMapper _mapper;

        public GetCategoriesByPostIdQueryHandler(IPostCategoryRepository postCategoryRepository, IMapper mapper)
        {
            _postCategoryRepository = postCategoryRepository;
            _mapper = mapper;
        }

        public async Task<IQueryable<CategoryPayload>> Handle(GetCategoriesByPostIdQuery request, CancellationToken cancellationToken)
        {
            var postCategories = await _postCategoryRepository.GetByPostId(request.PostId);
            var result = new List<CategoryPayload>();
            foreach(var postCategory in postCategories)
            {
                result.Add(_mapper.Map<CategoryPayload>(postCategory.Category));
            }

            return result.AsQueryable();
        }
    }
}
