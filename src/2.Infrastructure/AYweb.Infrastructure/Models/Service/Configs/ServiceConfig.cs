using AYweb.Domain.Common.ValueObjects.Conversion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AYweb.Infrastructure.Models.Service.Configs;

public class ServiceConfig : IEntityTypeConfiguration<Domain.Models.Service.Entities.Service>
{
    public void Configure(EntityTypeBuilder<Domain.Models.Service.Entities.Service> builder)
    {
        builder.Property(t => t.Title).HasConversion<TitleConversion>().HasMaxLength(250).IsRequired();

        builder.Property(t => t.Description).HasConversion<DescriptionConversion>().HasMaxLength(500).IsRequired();
        
        builder.HasOne(t => t.Parent);
    }
}
