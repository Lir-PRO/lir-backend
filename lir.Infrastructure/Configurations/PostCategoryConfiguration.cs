using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Lir.Core.Models;

namespace Lir.Infrastructure.Configurations
{
    public class PostCategoryConfiguration : IEntityTypeConfiguration<PostCategory>
    {
        public void Configure(EntityTypeBuilder<PostCategory> builder)
        {
            builder.HasKey(pc => new
            {
                pc.PostId,
                pc.CategoryId
            });

            builder.HasOne(pc => pc.Post)
                .WithMany(p => p.PostCategories)
                .HasForeignKey(pc => pc.CategoryId)
                .OnDelete(DeleteBehavior.Cascade); ;

            builder.HasOne(pc => pc.Category)
                   .WithMany(c => c.PostCategories)
                   .HasForeignKey(pc => pc.PostId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
