using AYweb.Domain.Common.ValueObjects.Conversion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace AYweb.Infrastructure.Models.Product.Configs;

public class ProductConfig : IEntityTypeConfiguration<Domain.Models.Product.Entities.Product>
{
    public void Configure(EntityTypeBuilder<Domain.Models.Product.Entities.Product> builder)
    {
        builder.Property(t => t.Name).HasMaxLength(400).IsRequired();

        builder.Property(t => t.ShortDescription).HasConversion<DescriptionConversion>().HasMaxLength(100).IsRequired();

        builder.Property(t => t.MainDescription).HasConversion<DescriptionConversion>().HasMaxLength(100).IsRequired();

        builder.Property(t => t.SeoDescription).HasConversion<DescriptionConversion>().HasMaxLength(100).IsRequired();

        builder.HasMany(t => t.Comments);
        builder.HasMany(t => t.Features);
        builder.HasMany(t => t.OrderLines);
    }
}
