using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Modules.Users.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddUsersInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }
}