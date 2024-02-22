using Lir.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore;
using Lir.Infrastructure.Configurations;


namespace Lir.Infrastructure.Persistence
{
    public class LirDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public LirDbContext(DbContextOptions<LirDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("uuid-ossp");

            modelBuilder.Entity<User>()
                       .HasBaseType<IdentityUser<Guid>>()
                       .ToTable("User");

            modelBuilder.ApplyConfiguration(new PostCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new UserBadgeConfiguration());
            modelBuilder.ApplyConfiguration(new UserChatConfiguration());
            modelBuilder.ApplyConfiguration(new UserSubscriptionConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new MessageConfiguration());
            modelBuilder.ApplyConfiguration(new ContentConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new ChatConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new BadgeConfiguration());

            modelBuilder.Entity<IdentityUserLogin<Guid>>().HasKey(x => x.UserId);
            modelBuilder.Entity<IdentityUserRole<Guid>>().HasKey(x => x.UserId);
            modelBuilder.Entity<IdentityUserToken<Guid>>().HasKey(x => x.UserId);
        }

        //User
        public DbSet<User> Users { get; set; }
        public DbSet<Badge> Badges { get; set; }
        public DbSet<UserBadge> UserBadges { get; set; }
        public DbSet<UserSubscription> UserSubscriptions { get; set; }

        //Chat
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<UserChat> UserChats { get; set; }

        //Post
        public DbSet<Post> Posts { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
    }
}
