using AutoMapper;
using Common;
using MediatR;
using Modules.Posts.Application.Common.Errors;
using Modules.Posts.Application.Common.Models;
using Modules.Posts.Domain.Entities;
using Modules.Posts.Domain.Interfaces;

namespace Modules.Posts.Application.Posts.Commands.UpdatePost
{
    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, Response<PostPayload>>
    {
        private readonly IPostRepository _postRepository;
        private readonly IContentRepository _contentRepository;
        private readonly IPostCategoryRepository _postCategoryRepository;
        private readonly IMapper _mapper;

        public UpdatePostCommandHandler(IMapper mapper, IPostCategoryRepository postCategoryRepository, IContentRepository contentRepository, IPostRepository postRepository)
        {
            _mapper = mapper;
            _postCategoryRepository = postCategoryRepository;
            _contentRepository = contentRepository;
            _postRepository = postRepository;
        }
        public async Task<Response<PostPayload>> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {

            if (request.Input.PostId == Guid.Empty)
            {
                return Response<PostPayload>.Failure(PostErrors.NullInput);
            }

            var post = await _postRepository.GetPostByIdAsync(request.Input.PostId);
            post.Caption = request.Input.Caption;
            foreach (var postCategory in post.PostCategories)
            {
                _postCategoryRepository.Delete(postCategory);
            }

            foreach (var categoryId in request.Input.CategoryIds)
            {
                var postCategory = new PostCategory()
                {
                    PostId = post.Id,
                    CategoryId = categoryId,
                };
                await _postCategoryRepository.AddAsync(postCategory);
            }

            foreach (var content in post.Contents)
            {
                await _contentRepository.DeleteAsync(content.Id, cancellationToken);
            }

            foreach (var contentInput in request.Input.ContentInputs)
            {
                var content = new Content()
                {
                    PostId = post.Id,
                    Base64 = contentInput.ContentBase64,
                    ContentType = contentInput.ContentType
                };

                await _contentRepository.AddAsync(content, cancellationToken);
            }

            await _postRepository.UpdateAsync(post.Id, post, cancellationToken);
            var payload = _mapper.Map<PostPayload>(post);

            return Response<PostPayload>.Success(payload);
        }
    }
}
