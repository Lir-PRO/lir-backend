using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modules.Chats.Application.Common.Interfaces;
using Modules.Chats.Domain.Interfaces;
using Modules.Chats.Persistence.Repositories;

namespace Modules.Chats.Persistence
{
    public static class ConfigureServices
    {
        public static async Task<IServiceCollection> AddChatsPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ChatContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("Postgre")));

            services.AddScoped<ChatDbContextInitializer>();
            var chatInitializer = services.BuildServiceProvider().GetRequiredService<ChatDbContextInitializer>();
            await chatInitializer.InitialiseAsync();

            services.AddScoped<IChatContext>(provider => provider.GetRequiredService<ChatContext>());
            services.AddScoped<IChatRepository, ChatRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();

            return services;
        }
    }
}
