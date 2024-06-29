using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modules.Users.Domain.Interfaces;
using Modules.Users.Persistence.Services;

namespace Modules.Users.Persistence
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddUsersPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<UserContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("Postgre")));

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IBadgeService, BadgeService>();
            services.AddScoped<ISubscriptionService, SubscriptionService>();

            return services;
        }
    }
}
