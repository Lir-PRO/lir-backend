using Lir.Api.GraphQL.Query;
using MassTransit;
using Modules.Chats.Endpoints;
using Modules.Posts.Endpoints;
using Modules.Posts.Endpoints.GraphQL.Mutations;
using Modules.Posts.Endpoints.GraphQL.Queries;
using Modules.Users.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddPostsServices(builder.Configuration);
builder.Services.AddChatsServices(builder.Configuration);
builder.Services.AddUsersServices(builder.Configuration);

builder.Services.AddMassTransit(x =>
{
    // Register consumers from different modules

    // Use in-memory transport
    x.UsingInMemory((context, cfg) =>
    {
        cfg.ConfigureEndpoints(context);
    });
});

//builder.Services.AddMassTransitHostedService();

builder.Services.AddGraphQLServer()
    .AddAuthorization()
    .AddFiltering()
    .AddSorting()
    .AddMutationType<PostMutation>()
    .AddQueryType<Query>();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.UseWebSockets();
app.UseHttpsRedirection();
app.MapGraphQL();
app.Run();