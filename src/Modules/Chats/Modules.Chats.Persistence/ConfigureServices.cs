using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modules.Chats.Domain.Interfaces;
using Modules.Chats.Persistence.Services;

namespace Modules.Chats.Persistence
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddChatsPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ChatContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("Postgre")));

            services.AddScoped<IChatService, ChatService>();
            services.AddScoped<IMessageService, MessageService>();

            return services;
        }
    }
}
