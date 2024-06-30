using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modules.Posts.Infrastructure.Consumers;

namespace Modules.Posts.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddPostsInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }
}