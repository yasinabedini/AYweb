using AYweb.Domain.Common.ValueObjects.Conversion;
using AYweb.Domain.Models.Blog.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AYweb.Infrastructure.Models.Blog.Configs;

public class BlogGroupConfig : IEntityTypeConfiguration<BlogGroup>
{
    public void Configure(EntityTypeBuilder<BlogGroup> builder)
    {
        builder.Property(t => t.Title).HasConversion<TitleConversion>().HasMaxLength(250).IsRequired();
    }
}
