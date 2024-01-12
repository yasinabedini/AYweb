using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AYweb.Domain.Models.Notification.Entities.Configs;

public class UserNotificationConfig : IEntityTypeConfiguration<UserNotification>
{
    public void Configure(EntityTypeBuilder<UserNotification> builder)
    {
        builder.HasOne(t => t.User);
        
        builder.HasOne(t => t.Notification);
    }
}
