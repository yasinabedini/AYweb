using AYweb.Domain.Common.ValueObjects.Conversion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AYweb.Domain.Models.Blog.Entities.Configs;

public class BlogConfig : IEntityTypeConfiguration<Blog>
{
    public void Configure(EntityTypeBuilder<Blog> builder)
    {

        builder.Property(t=>t.Text).HasMaxLength(500).IsRequired();
        builder.HasOne(t => t.Author);

        builder.Property(t => t.ImageName).IsRequired();

       // builder.HasMany(t => t.Galleries);       
        
       builder.HasMany(t => t.Groups);
    }
}
