using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Modules.Chats.Application;
using Modules.Chats.Endpoints.GraphQL.Mutations;
using Modules.Chats.Endpoints.GraphQL.Queries;
using Modules.Chats.Endpoints.GraphQL.Subscriptions;
using Modules.Chats.Infrastructure;
using Modules.Chats.Persistence;

namespace Modules.Chats.Endpoints;

public static class ConfigureServices
{
    public static async Task<IServiceCollection> AddChatsServices(this IServiceCollection services, IConfiguration configuration)
    {
        await services.AddChatsPersistenceServices(configuration);
        services.AddChatsApplicationServices(configuration);
        services.AddChatsInfrastructureServices(configuration);

        services.AddScoped<ChatMutation>();
        services.AddScoped<MessageMutation>();

        services.AddScoped<ChatQuery>();

        services.AddSingleton<ChatSubscriptions>();

        return services;
    }
}