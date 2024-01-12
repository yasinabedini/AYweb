using AYweb.Domain.Common.ValueObjects.Conversion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Domain.Models.Product.Entities.Configs
{
    public class CommentConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(t => t.Title).HasConversion<TitleConversion>().HasMaxLength(250).IsRequired();

            builder.Property(t => t.Text).HasConversion<DescriptionConversion>().HasMaxLength(500).IsRequired();

            builder.Property(t=>t.UserName).HasMaxLength(100).IsRequired();

            builder.Property(t => t.UserPhoneNumber).HasConversion<PhoneNumberConversion>().HasMaxLength(20).IsRequired();

            builder.HasOne(t => t.Product);
        }
    }
}
