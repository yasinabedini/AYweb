using AYweb.Domain.Common.ValueObjects.Conversion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AYweb.Infrastructure.Models.Service.Configs;

public class ServiceConfig : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> builder)
    {
        builder.Property(t => t.Title).HasConversion<TitleConversion>().HasMaxLength(250).IsRequired();

        builder.Property(t => t.Description).HasConversion<DescriptionConversion>().HasMaxLength(500).IsRequired();

        builder.HasOne(t => t.Image);

        builder.HasOne(t => t.Parent);
    }
}
