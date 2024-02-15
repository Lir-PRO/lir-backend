using Lir.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var conncectionString = builder.Configuration.GetConnectionString("Postgre");
builder.Services.AddDbContextFactory<LirDbContext>(options =>
{
    options.UseNpgsql(conncectionString,
        b => b.MigrationsAssembly("Lir.Infrastructure"));
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
