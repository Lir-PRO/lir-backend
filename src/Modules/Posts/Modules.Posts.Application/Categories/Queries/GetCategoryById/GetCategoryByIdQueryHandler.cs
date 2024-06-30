using AutoMapper;
using MediatR;
using Modules.Posts.Application.Common.Models;
using Modules.Posts.Domain.Interfaces;

namespace Modules.Posts.Application.Categories.Queries.GetCategoryById;


public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryPayload>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public GetCategoryByIdQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<CategoryPayload> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(request.Id);

        return _mapper.Map<CategoryPayload>(category);
    }
}