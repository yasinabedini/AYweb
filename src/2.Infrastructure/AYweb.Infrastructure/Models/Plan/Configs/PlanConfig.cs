using AYweb.Domain.Common.ValueObjects.Conversion;
using AYweb.Domain.Models.Plan.ValueObjects.Conversion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Infrastructure.Models.Plan.Configs
{
    public class PlanConfig : IEntityTypeConfiguration<Plan>
    {
        public void Configure(EntityTypeBuilder<Plan> builder)
        {
            builder.Property(t => t.Title).HasConversion<TitleConversion>().HasMaxLength(250).IsRequired();

            builder.Property(t => t.PlanType).HasConversion<PlanTypeConversion>().HasMaxLength(100).IsRequired();

            //            builder.Property(t => t.planFeatures).HasConversion<PlanFeatureConversion>().HasMaxLength(100).IsRequired();
        }
    }
}
