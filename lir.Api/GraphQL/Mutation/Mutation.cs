using Lir.Api.Authentication;
using Lir.Api.GraphQL.InputTypes;
using Lir.Api.GraphQL.Payload;
using Lir.Core.Interfaces;
using Lir.Core.Models;

namespace Lir.Api.GraphQL.Mutation
{
    public class Mutation
    {
        public async Task<LoginUserPayload> LoginUser(string email, string password, IAuthenticationService authenticationService)
        {
            var input = new LoginInputType()
            {
                Email = email,
                Password = password
            };
            return await authenticationService.Login(input);
        }

        public async Task<RegisterUserPayload> RegisterUser(string email, string username, string name, string bio, string password, string passwordConfirmation, IAuthenticationService authenticationService)
        {
            var input = new RegisterInputType()
            {
                Email = email,
                Name = name,
                Username = username,
                Password = password,
                Bio = bio,
                ConfirmPassword = passwordConfirmation
            };
            return await authenticationService.Register(input);
        }

        public async Task<Post> AddPost(AddPostInput input,
            [Service] IPostService postService,
            [Service] IContentService contentService,
            [Service] IPostCategoryService postCategoryService)
        {
            var post = new Post
            {
                UserId = input.UserId,
                Caption = input.Caption
            };

            await postService.AddAsync(post);

            foreach (var categoryId in input.CategoryIds)
            {
                var postCategory = new PostCategory()
                {
                    PostId = post.Id,
                    CategoryId = categoryId
                };
                await postCategoryService.AddAsync(postCategory);
            }

            foreach (var contentInput in input.ContentInputs)
            {
                var content = new Content()
                {
                    PostId = post.Id,
                    ContentBase64 = contentInput.ContentBase64,
                    ContentType = contentInput.ContentType
                };

                await contentService.AddAsync(content);
            }

            await postService.UpdateAsync(post.Id, post);
            return post;
        }

        public async Task<Category> AddCategory(string name, string description, [Service] ICategoryService categoryService)
        {
            var category = new Category()
            {
                Name = name,
                Description = description
            };
            await categoryService.AddAsync(category);

            return category;
        }
    }
}
