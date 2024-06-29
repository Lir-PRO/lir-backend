using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Modules.Chats.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddChatsApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }
}