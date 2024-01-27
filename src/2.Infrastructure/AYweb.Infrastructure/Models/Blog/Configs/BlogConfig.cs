using AYweb.Domain.Common.ValueObjects.Conversion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AYweb.Infrastructure.Models.Blog.Configs;

public class BlogConfig : IEntityTypeConfiguration<Domain.Models.Blog.Entities.Blog>
{
    public void Configure(EntityTypeBuilder<Domain.Models.Blog.Entities.Blog> builder)
    {

        builder.Property(t => t.Text).HasMaxLength(500).IsRequired();
        builder.HasOne(t => t.Author);

        builder.Property(t => t.Title).HasConversion<TitleConversion>();

        builder.Property(t => t.Summary).HasConversion<DescriptionConversion>();

        builder.Property(t => t.Introduction).HasConversion<DescriptionConversion>();

        builder.Property(t => t.ImageName).IsRequired();

        builder.HasMany(t => t.Galleries);       

        builder.HasMany(t => t.Groups);
        
        builder.HasMany(t => t.Comments);
    }
}
