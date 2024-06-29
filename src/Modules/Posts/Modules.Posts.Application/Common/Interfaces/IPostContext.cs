using Microsoft.EntityFrameworkCore;
using Modules.Posts.Domain.Entities;

namespace Modules.Posts.Application.Common.Interfaces;

public interface IPostContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Content> Contents { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<PostCategory> PostCategories { get; set; }
}