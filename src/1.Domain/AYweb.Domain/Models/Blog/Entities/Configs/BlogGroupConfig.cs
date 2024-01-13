using AYweb.Domain.Common.ValueObjects.Conversion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AYweb.Domain.Models.Blog.Entities.Configs;

public class BlogGroupConfig : IEntityTypeConfiguration<BlogGroup>
{
    public void Configure(EntityTypeBuilder<BlogGroup> builder)
    {            
        builder.Property(t => t.Title).HasConversion<TitleConversion>().HasMaxLength(250).IsRequired();
    }
}
