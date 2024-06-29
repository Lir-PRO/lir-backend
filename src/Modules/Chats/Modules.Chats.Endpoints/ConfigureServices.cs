using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Modules.Chats.Application;
using Modules.Chats.Infrastructure;
using Modules.Chats.Persistence;

namespace Modules.Chats.Endpoints;

public static class ConfigureServices
{
    public static IServiceCollection AddChatsServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddChatsPersistenceServices(configuration);
        services.AddChatsApplicationServices(configuration);
        services.AddChatsInfrastructureServices(configuration);

        return services;
    }
}