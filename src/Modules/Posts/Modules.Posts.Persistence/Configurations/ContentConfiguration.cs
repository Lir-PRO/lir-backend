using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modules.Posts.Domain.Entities;
using Modules.Posts.Domain.Enums;

namespace Modules.Posts.Persistence.Configurations;

public class ContentConfiguration : IEntityTypeConfiguration<Content>
{
    public void Configure(EntityTypeBuilder<Content> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .ValueGeneratedOnAdd();

        builder.Property(e => e.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.UpdatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnUpdate();

        builder.Property(c => c.ContentType)
            .HasConversion(c => c.ToString(), c => Enum.Parse<ContentType>(c))
            .IsRequired();

        builder.Property(c => c.Base64)
            .IsRequired();

        // Foreign key
        builder.Property(c => c.PostId)
            .IsRequired();

        // Navigation property
        builder.HasOne(c => c.Post)
            .WithMany(p => p.Contents)
            .HasForeignKey(c => c.PostId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}