﻿using AYweb.Domain.Common.ValueObjects.Conversion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AYweb.Domain.Models.Blog.Entities.Configs;

public class BlogCommentConfig : IEntityTypeConfiguration<BlogComment>
{
    public void Configure(EntityTypeBuilder<BlogComment> builder)
    {
        builder.Property(t => t.UserName).HasMaxLength(100).IsRequired();

        builder.Property(t => t.UserPhoneNumber).HasConversion<PhoneNumberConversion>().HasMaxLength(20).IsRequired();
        
        builder.Property(t => t.Text).HasMaxLength(500).IsRequired();

        builder.HasOne(t => t.Blog);
        
    }
}
