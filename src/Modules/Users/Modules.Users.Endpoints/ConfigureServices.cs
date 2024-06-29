using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modules.Users.Application;
using Modules.Users.Infrastructure;
using Modules.Users.Persistence;

namespace Modules.Users.Endpoints;

public static class ConfigureServices
{
    public static IServiceCollection AddUsersServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddUsersPersistenceServices(configuration);
        services.AddUsersInfrastructureServices(configuration);
        services.AddUsersApplicationServices(configuration);

        return services;
    }
}