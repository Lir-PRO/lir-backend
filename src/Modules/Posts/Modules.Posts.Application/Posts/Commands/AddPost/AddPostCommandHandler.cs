using AutoMapper;
using MediatR;
using Modules.Posts.Application.Common.Models;
using Modules.Posts.Domain.Entities;
using Modules.Posts.Domain.Interfaces;

namespace Modules.Posts.Application.Posts.Commands.AddPost
{
    public class AddPostCommandHandler : IRequestHandler<AddPostCommand, PostPayload>
    {
        private readonly IPostService _postService;
        private readonly IContentService _contentService;
        private readonly IPostCategoryService _postCategoryService; 
        private readonly IMapper _mapper;

        public AddPostCommandHandler(IPostCategoryService postCategoryService, IContentService contentService, IPostService postService, IMapper mapper)
        {
            _postCategoryService = postCategoryService;
            _contentService = contentService;
            _postService = postService;
            _mapper = mapper;
        }

        public async Task<PostPayload> Handle(AddPostCommand request, CancellationToken cancellationToken)
        {
            var post = new Post
            {
                UserId = request.Input.UserId,
                Caption = request.Input.Caption
            };

            await _postService.AddAsync(post);

            foreach (var categoryId in request.Input.CategoryIds)
            {
                var postCategory = new PostCategory()
                {
                    PostId = post.Id,
                    CategoryId = categoryId
                };
                await _postCategoryService.AddAsync(postCategory);
            }

            foreach (var contentInput in request.Input.ContentInputs)
            {
                var content = new Content()
                {
                    PostId = post.Id,
                    Base64 = contentInput.ContentBase64,
                    ContentType = contentInput.ContentType
                };

                await _contentService.AddAsync(content);
            }

            await _postService.UpdateAsync(post.Id, post);
            return _mapper.Map<PostPayload>(post);
        }
    }
}
