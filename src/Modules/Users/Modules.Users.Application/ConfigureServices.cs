using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Modules.Users.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddUsersApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }
}