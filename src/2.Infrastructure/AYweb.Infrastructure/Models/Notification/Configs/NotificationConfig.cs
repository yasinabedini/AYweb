using AYweb.Domain.Common.ValueObjects.Conversion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AYweb.Infrastructure.Models.Notification.Configs;

public class NotificationConfig : IEntityTypeConfiguration<Domain.Models.Notification.Entities.Notification>
{
    public void Configure(EntityTypeBuilder<Domain.Models.Notification.Entities.Notification> builder)
    {
        builder.Property(t => t.Title).HasConversion<TitleConversion>().HasMaxLength(250).IsRequired();
    }
}
