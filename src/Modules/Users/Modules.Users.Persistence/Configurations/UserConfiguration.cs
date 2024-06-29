using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modules.Users.Domain.Entities;

namespace Modules.Users.Persistence.Configurations;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.CreatedAt)
            .ValueGeneratedOnAdd();

        builder.Property(e => e.UpdatedAt)
            .ValueGeneratedOnUpdate();

        builder.Property(e => e.Bio)
            .HasMaxLength(255)
            .IsRequired(false);

        builder.Property(e => e.Name)
            .HasMaxLength(255)
            .IsRequired(false);

        builder.Property(e => e.ProfilePictureBase64)
            .IsRequired(false);

        builder.Property(e => e.RefreshToken)
            .IsRequired(false);

        // Navigation properties
        builder.HasMany(u => u.UserBadges)
            .WithOne(ub => ub.User)
            .HasForeignKey(ub => ub.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}