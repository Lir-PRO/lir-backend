using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Modules.Chats.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddChatsInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }
}