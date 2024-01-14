using AYweb.Domain.Models.Notification.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AYweb.Infrastructure.Models.Notification.Configs;

public class UserNotificationConfig : IEntityTypeConfiguration<UserNotification>
{
    public void Configure(EntityTypeBuilder<UserNotification> builder)
    {
        builder.HasOne(t => t.User);

        builder.HasOne(t => t.Notification);
    }
}
