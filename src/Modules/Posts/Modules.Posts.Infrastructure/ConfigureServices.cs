using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Modules.Posts.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddPostsInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }
}