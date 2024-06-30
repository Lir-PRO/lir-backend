using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modules.Posts.Application.Common.Interfaces;
using Modules.Posts.Domain.Interfaces;
using Modules.Posts.Persistence.Repositories;

namespace Modules.Posts.Persistence
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddPostsPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PostContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("Postgre")));

            services.AddScoped<IPostContext>(provider => provider.GetRequiredService<PostContext>());
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IContentRepository, ContentRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IPostCategoryRepository, PostCategoryRepository>();

            return services;
        }
    }
}