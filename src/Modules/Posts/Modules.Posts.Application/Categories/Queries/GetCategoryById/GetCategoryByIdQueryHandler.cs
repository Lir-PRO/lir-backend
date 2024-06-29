using AutoMapper;
using MediatR;
using Modules.Posts.Application.Common.Models;
using Modules.Posts.Domain.Interfaces;

namespace Modules.Posts.Application.Categories.Queries.GetCategoryById;


public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryPayload>
{
    private readonly ICategoryService _categoryService;
    private readonly IMapper _mapper;

    public GetCategoryByIdQueryHandler(ICategoryService categoryService, IMapper mapper)
    {
        _categoryService = categoryService;
        _mapper = mapper;
    }

    public async Task<CategoryPayload> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await _categoryService.GetByIdAsync(request.Id);

        return _mapper.Map<CategoryPayload>(category);
    }
}