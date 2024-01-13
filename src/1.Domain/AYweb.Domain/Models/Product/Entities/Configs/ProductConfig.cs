using AYweb.Domain.Common.ValueObjects.Conversion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AYweb.Domain.Models.Product.Entities.Configs;

public class ProductConfig : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(t => t.Name).HasMaxLength(400).IsRequired();

        builder.Property(t=>t.ShortDescription).HasConversion<DescriptionConversion>().HasMaxLength(100).IsRequired();
        
        builder.Property(t=>t.MainDescription).HasConversion<DescriptionConversion>().HasMaxLength(100).IsRequired();
        
        builder.Property(t=>t.SeoDescription).HasConversion<DescriptionConversion>().HasMaxLength(100).IsRequired();

        builder.HasMany(t => t.Comments);
        builder.HasMany(t => t.Features);
        //builder.HasMany(t => t.OrderLines);
    }
}
