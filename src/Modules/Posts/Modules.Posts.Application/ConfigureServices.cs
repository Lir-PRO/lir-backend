using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Modules.Posts.Application;
public static class ConfigureServices
{
    public static IServiceCollection AddPostsApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }
}