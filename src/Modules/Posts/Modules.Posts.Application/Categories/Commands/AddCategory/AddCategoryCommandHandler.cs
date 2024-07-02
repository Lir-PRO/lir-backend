using AutoMapper;
using MediatR;
using Modules.Posts.Application.Common.Models;
using Modules.Posts.Application.Posts.Commands.AddPost;
using Modules.Posts.Domain.Entities;
using Modules.Posts.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Posts.Application.Categories.Commands.AddCategory;

public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand, CategoryPayload>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public AddCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<CategoryPayload> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Category
        {
            Name = request.Name,
            Description = request.Description
        };

        await _categoryRepository.AddAsync(category);

        return _mapper.Map<CategoryPayload>(category);
    }
}
