using AutoMapper;
using MediatR;
using Modules.Posts.Application.Common.Models;
using Modules.Posts.Domain.Entities;
using Modules.Posts.Domain.Interfaces;

namespace Modules.Posts.Application.Posts.Commands.AddPost
{
    public class AddPostCommandHandler : IRequestHandler<AddPostCommand, PostPayload>
    {
        private readonly IPostRepository _postRepository;
        private readonly IContentRepository _contentRepository;
        private readonly IPostCategoryRepository _postCategoryRepository; 
        private readonly IMapper _mapper;

        public AddPostCommandHandler(IPostCategoryRepository postCategoryRepository, IContentRepository contentRepository, IPostRepository postRepository, IMapper mapper)
        {
            _postCategoryRepository = postCategoryRepository;
            _contentRepository = contentRepository;
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<PostPayload> Handle(AddPostCommand request, CancellationToken cancellationToken)
        {
            var post = new Post
            {
                UserId = request.Input.UserId,
                Caption = request.Input.Caption
            };

            await _postRepository.AddAsync(post);

            foreach (var categoryId in request.Input.CategoryIds)
            {
                var postCategory = new PostCategory()
                {
                    PostId = post.Id,
                    CategoryId = categoryId
                };
                await _postCategoryRepository.AddAsync(postCategory);
            }

            foreach (var contentInput in request.Input.ContentInputs)
            {
                var content = new Content()
                {
                    PostId = post.Id,
                    Base64 = contentInput.ContentBase64,
                    ContentType = contentInput.ContentType
                };

                await _contentRepository.AddAsync(content);
            }

            await _postRepository.UpdateAsync(post.Id, post);
            return _mapper.Map<PostPayload>(post);
        }
    }
}
