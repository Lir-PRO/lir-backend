using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modules.Users.Application.Common.Interfaces;
using Modules.Users.Application.Services;

namespace Modules.Users.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddUsersApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IAuth0Service, Auth0Service>();
        return services;
    }
}