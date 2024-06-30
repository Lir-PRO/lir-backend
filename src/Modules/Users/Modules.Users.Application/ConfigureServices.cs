using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modules.Users.Application.Common.Interfaces;
using Modules.Users.Application.Common.Models;
using Modules.Users.Application.Services;
using System.Reflection;

namespace Modules.Users.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddUsersApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<Auth0Settings>(configuration.GetSection("Auth0"));

        services.AddMediatR(options =>
        {
            options.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        
        services.AddScoped<IAuth0Service, Auth0Service>();
        return services;
    }
}