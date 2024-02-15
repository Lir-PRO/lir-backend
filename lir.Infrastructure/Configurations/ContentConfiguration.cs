using Lir.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lir.Core.Enums;

namespace Lir.Infrastructure.Configurations
{
    public class ContentConfiguration : IEntityTypeConfiguration<Content>
    {
        public void Configure(EntityTypeBuilder<Content> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd();

            builder.Property(c => c.ContentType)
                .HasConversion(c => c.ToString(), c => Enum.Parse<ContentType>(c))
                .IsRequired();

            builder.Property(c => c.ContentBase64)
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
}
