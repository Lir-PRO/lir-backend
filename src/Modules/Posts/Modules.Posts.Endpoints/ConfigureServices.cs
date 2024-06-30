using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modules.Posts.Application;
using Modules.Posts.Endpoints.GraphQL.Mutations;
using Modules.Posts.Endpoints.GraphQL.Queries;
using Modules.Posts.Infrastructure;
using Modules.Posts.Persistence;

namespace Modules.Posts.Endpoints;

public static class ConfigureServices
{
    public static IServiceCollection AddPostsServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPostsPersistenceServices(configuration);
        services.AddPostsApplicationServices(configuration);
        services.AddPostsInfrastructureServices(configuration);

        services.AddScoped<PostQuery>();
        services.AddScoped<CategoryQuery>();
        services.AddScoped<PostMutation>();

        return services;
    }
}