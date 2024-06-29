using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modules.Posts.Domain.Interfaces;
using Modules.Posts.Persistence.Services;

namespace Modules.Posts.Persistence
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddPostsPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PostContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("Postgre")));

            services.AddScoped<IPostService, PostService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IContentService, ContentService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IPostCategoryService, PostCategoryService>();

            return services;
        }
    }
}