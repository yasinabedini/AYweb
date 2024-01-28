using AYweb.Domain.Common.ValueObjects.Conversion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Infrastructure.Models.Project.Configs;

public class ProjectConfig : IEntityTypeConfiguration<Domain.Models.Project.Entities.Project>
{
    public void Configure(EntityTypeBuilder<Domain.Models.Project.Entities.Project> builder)
    {
        builder.Property(t => t.Title).HasConversion<TitleConversion>().HasMaxLength(250).IsRequired();

        builder.Property(t => t.ShortDescription).HasConversion<DescriptionConversion>().HasMaxLength(500).IsRequired();

        builder.Property(t => t.Description).HasConversion<DescriptionConversion>().HasMaxLength(500).IsRequired();

        builder.Property(t => t.ShamsiDateString).HasMaxLength(150).IsRequired();

        builder.Property(t => t.CustomerName).HasMaxLength(100).IsRequired();

        builder.Property(t => t.RelatedService).HasMaxLength(100).IsRequired();

        builder.Property(t => t.Link).HasMaxLength(200).IsRequired();
        
    }
}
