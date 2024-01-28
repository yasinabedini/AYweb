using AYweb.Domain.Common.ValueObjects.Conversion;
using AYweb.Domain.Models.User.Entities;
using AYweb.Domain.Models.User.ValueObjects.Conversion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Infrastructure.Models.User.Configs
{
    public class CounselingConfig : IEntityTypeConfiguration<Counseling>
    {
        public void Configure(EntityTypeBuilder<Counseling> builder)
        {
            builder.Property(t => t.PhoneNumber).HasConversion<PhoneNumberConversion>().HasMaxLength(20).IsRequired();

            builder.Property(t => t.Title).HasConversion<TitleConversion>().HasMaxLength(200).IsRequired();

            builder.Property(t => t.Message).HasConversion<DescriptionConversion>().HasMaxLength(2000).IsRequired();
        }
    }
}
