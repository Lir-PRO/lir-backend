using Lir.Api.Authentication;
using Lir.Api.GraphQL.Mutation;
using Lir.Api.GraphQL.Query;
using Lir.Core.Interfaces;
using Lir.Infrastructure.Persistence;
using Lir.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Postgre");

builder.Services.AddDbContextPool<LirDbContext>(options =>
{
    options.UseNpgsql(connectionString,
        b => b.MigrationsAssembly("Lir.Infrastructure"));
});
builder.Services.AddPooledDbContextFactory<LirDbContext>(options =>
{
    options.UseNpgsql(connectionString,
        b => b.MigrationsAssembly("Lir.Infrastructure"));
});

builder.Services.AddTransient<IBadgeService, BadgeService>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<IChatService, ChatService>();
builder.Services.AddTransient<ICommentService, CommentService>();
builder.Services.AddTransient<IContentService, ContentService>();
builder.Services.AddTransient<IMessageService, MessageService>();
builder.Services.AddTransient<IPostService, PostService>();
builder.Services.AddTransient<ISubscriptionService, SubscriptionService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUserRolesService, UserRolesService>();
builder.Services.AddTransient<IAuthenticationService, AuthenticationService>();
builder.Services.AddTransient<IPostCategoryService, PostCategoryService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.Configure<TokenSettings>(builder.Configuration.GetSection("TokenSettings"));

builder.Services.AddGraphQLServer()
    .AddMutationConventions()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .RegisterService<IAuthenticationService>();

var app = builder.Build();

app.UseWebSockets();
app.UseHttpsRedirection();
app.MapGraphQL();
app.Run();
