using Lir.Core.Interfaces;
using Lir.Infrastructure.Persistence;
using Lir.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var conncectionString = builder.Configuration.GetConnectionString("Postgre");
builder.Services.AddDbContextFactory<LirDbContext>(options =>
{
    options.UseNpgsql(conncectionString,
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

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
