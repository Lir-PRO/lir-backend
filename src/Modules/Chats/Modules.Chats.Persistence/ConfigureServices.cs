using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modules.Chats.Domain.Interfaces;
using Modules.Chats.Persistence.Repositories;

namespace Modules.Chats.Persistence
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddChatsPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ChatContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("Postgre")));

            services.AddScoped<IChatRepository, ChatRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();

            return services;
        }
    }
}
