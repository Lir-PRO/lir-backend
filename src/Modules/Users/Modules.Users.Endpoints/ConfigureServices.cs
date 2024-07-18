using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modules.Users.Application;
using Modules.Users.Application.Common.Models;
using Modules.Users.Endpoints.GraphQL.Mutations;
using Modules.Users.Endpoints.GraphQL.Queries;
using Modules.Users.Infrastructure;
using Modules.Users.Persistence;

namespace Modules.Users.Endpoints;

public static class ConfigureServices
{
    public static async Task<IServiceCollection> AddUsersServices(this IServiceCollection services, IConfiguration configuration)
    {
        await services.AddUsersPersistenceServices(configuration);
        services.AddUsersInfrastructureServices(configuration);
        services.AddUsersApplicationServices(configuration);

        services.AddScoped<UserMutation>();
        services.AddScoped<SubscriptionMutation>();

        services.AddScoped<UserQuery>();

        var auth0Settings = configuration.GetSection("Auth0").Get<Auth0Settings>();
        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.Authority = $"https://{auth0Settings.Domain}/";
                options.Audience = auth0Settings.Audience;
            });

        services.AddAuthorization(options =>
        {
            options.AddPolicy("AuthorizedUser", policy => policy.RequireAuthenticatedUser());
        });

        return services;
    }
}