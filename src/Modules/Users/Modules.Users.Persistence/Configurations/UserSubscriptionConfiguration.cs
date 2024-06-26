﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modules.Users.Domain.Entities;

namespace Modules.Users.Persistence.Configurations;

public class UserSubscriptionConfiguration : IEntityTypeConfiguration<UserSubscription>
{
    public void Configure(EntityTypeBuilder<UserSubscription> builder)
    {
        builder.HasKey(us => new
        {
            us.UserId,
            us.SubscriberId
        });

        builder.HasOne(us => us.User)
            .WithMany(u => u.Subscribers)
            .HasForeignKey(us => us.UserId)
            .HasPrincipalKey(u => u.Id);

        builder.HasOne(us => us.Subscriber)
            .WithMany(u => u.Subscriptions)
            .HasForeignKey(us => us.SubscriberId)
            .HasPrincipalKey(u => u.Id);
    }
}