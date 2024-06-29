using AutoMapper;
using MediatR;
using Modules.Posts.Application.Common.Models;
using Modules.Posts.Domain.Entities;
using Modules.Posts.Domain.Interfaces;

namespace Modules.Posts.Application.Posts.Commands.UpdatePost
{
    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, PostPayload>
    {
        private readonly IPostService _postService;
        private readonly IContentService _contentService;
        private readonly IPostCategoryService _postCategoryService;
        private readonly IMapper _mapper;

        public UpdatePostCommandHandler(IMapper mapper, IPostCategoryService postCategoryService, IContentService contentService, IPostService postService)
        {
            _mapper = mapper;
            _postCategoryService = postCategoryService;
            _contentService = contentService;
            _postService = postService;
        }
        public async Task<PostPayload> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            var post = await _postService.GetPostByIdAsync(request.Input.PostId);
            post.Caption = request.Input.Caption;
            foreach (var postCategory in post.PostCategories)
            {
                _postCategoryService.Delete(postCategory);
            }

            foreach (var categoryId in request.Input.CategoryIds)
            {
                var postCategory = new PostCategory()
                {
                    PostId = post.Id,
                    CategoryId = categoryId,
                };
                await _postCategoryService.AddAsync(postCategory);
            }

            foreach (var content in post.Contents)
            {
                await _contentService.DeleteAsync(content.Id);
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
