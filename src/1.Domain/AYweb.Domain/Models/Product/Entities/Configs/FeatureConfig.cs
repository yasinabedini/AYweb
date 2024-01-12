using AYweb.Domain.Common.ValueObjects.Conversion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AYweb.Domain.Models.Product.Entities.Configs;

public class FeatureConfig : IEntityTypeConfiguration<Feature>
{
    public void Configure(EntityTypeBuilder<Feature> builder)
    {
        builder.Property(t => t.Title).HasConversion<TitleConversion>().HasMaxLength(250).IsRequired();

        builder.Property(t => t.Value).HasMaxLength(250).IsRequired();

        builder.HasOne(t => t.Product);
    }
}
