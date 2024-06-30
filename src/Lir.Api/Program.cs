using Lir.Api.GraphQL.Mutation;
using Lir.Api.GraphQL.Query;
using MassTransit;
using Modules.Chats.Endpoints;
using Modules.Posts.Endpoints;
using Modules.Users.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddPostsServices(builder.Configuration);
builder.Services.AddChatsServices(builder.Configuration);
builder.Services.AddUsersServices(builder.Configuration);

builder.Services.AddMassTransit(x =>
{
    var assemblies = AppDomain.CurrentDomain.GetAssemblies()
        .Where(assembly => assembly.FullName.StartsWith("Modules."))
        .ToArray();

    x.AddConsumers(assemblies);

    x.UsingInMemory((context, cfg) =>
    {
        cfg.ConfigureEndpoints(context);
    });
});

builder.Services.AddGraphQLServer()
    .AddAuthorization()
    .AddFiltering()
    .AddSorting()
    .AddMutationType<Mutation>()
    .AddQueryType<Query>();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.UseWebSockets();
app.UseHttpsRedirection();
app.MapGraphQL();
app.Run();