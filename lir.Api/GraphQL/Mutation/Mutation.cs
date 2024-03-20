using Lir.Api.GraphQL.InputTypes;
using Lir.Application.Authentication;
using Lir.Application.Authentication.ImputTypes;
using Lir.Application.Authentication.Payload;
using Lir.Core.Interfaces;
using Lir.Core.Models;

namespace Lir.Api.GraphQL.Mutation
{
    public class Mutation
    {
        public async Task<LoginUserPayload> LoginUser(LoginUserInput input, IAuthenticationService authenticationService)
        {
            return await authenticationService.Login(input);
        }

        public async Task<RegisterUserPayload> RegisterUser(RegisterUserInput userInput, IAuthenticationService authenticationService)
        {
            return await authenticationService.Register(userInput);
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

        public async Task<Post> UpdatePost(UpdatePostInput input,
            [Service] IPostService postService,
            [Service] IContentService contentService,
            [Service] IPostCategoryService postCategoryService)
        {
            var post = await postService.GetPostByIdAsync(input.PostId);
            post.Caption = input.Caption;
            foreach (var postCategory in post.PostCategories)
            { 
                postCategoryService.Delete(postCategory);
            }

            foreach (var categoryId in input.CategoryIds)
            {
                var postCategory = new PostCategory()
                {
                    PostId = post.Id,
                    CategoryId = categoryId,
                };
                await postCategoryService.AddAsync(postCategory);
            }

            foreach (var content in post.Contents)
            {
                await contentService.DeleteAsync(content.Id);
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

        public async Task<Category> UpdateCategory(Guid categoryId, string name, string description, [Service] ICategoryService categoryService)
        {
            var category = await categoryService.GetByIdAsync(categoryId);
            category.Name = name;
            category.Description = description;

            await categoryService.UpdateAsync(categoryId, category);

            return category;
        }

        public async Task<Comment> AddComment(AddCommentInput input, [Service] ICommentService commentService)
        {
            var comment = new Comment()
            {
                UserId = input.UserId,
                PostId = input.PostId,
                Content = input.Content
            };
            await commentService.AddAsync(comment);
            return comment;
        }

        public async Task<Comment> UpdateComment(UpdateCommentInput input, [Service] ICommentService commentService)
        {
            var comment = await commentService.GetByIdAsync(input.CommentId);
            comment.Content = input.Content;

            await commentService.UpdateAsync(input.CommentId, comment);

            return comment;
        }


        public async Task DeletePost(Guid postId, [Service] IPostService postService)
        {
            await postService.DeleteAsync(postId);
        }

        public async Task DeleteComment(Guid commentId, [Service] ICommentService commentService)
        {
            await commentService.DeleteAsync(commentId);
        }

        public async Task DeleteCategory(Guid categoryId, [Service] ICategoryService categoryService)
        {
            await categoryService.DeleteAsync(categoryId);
        } 
    }
}
