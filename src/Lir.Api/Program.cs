using Lir.Api.GraphQL.Mutation;
using Lir.Api.GraphQL.Query;
using Lir.Api.GraphQL.Subscription;
using Lir.Api.Infrastructure;
using MassTransit;
using Modules.Chats.Endpoints;
using Modules.Chats.Endpoints.GraphQL.Mutations;
using Modules.Chats.Endpoints.GraphQL.Subscriptions;
using Modules.Posts.Endpoints;
using Modules.Users.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
await builder.Services.AddPostsServices(builder.Configuration);
await builder.Services.AddChatsServices(builder.Configuration);
await builder.Services.AddUsersServices(builder.Configuration);

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

builder.Services.AddHttpContextAccessor();
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        policy => { policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyHeader(); });
});

builder.Services.AddGraphQLServer()
    .AddAuthorization()
    .AddFiltering()
    .AddSorting()
    .AddMutationType<Mutation>()
    .AddQueryType<Query>()
    .AddSubscriptionType<ChatSubscriptions>()
    .AddInMemorySubscriptions();
builder.Services.AddProblemDetails();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

var app = builder.Build();

app.UseWebSockets();
app.UseRouting();
app.UseCors("CorsPolicy");
app.UseExceptionHandler();
app.UseAuthentication();
app.UseAuthorization();

app.MapGraphQL();

app.Run();