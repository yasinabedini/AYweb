using AYweb.Domain.Common.ValueObjects.Conversion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Infrastructure.Models.Permission.Configs
{
    public class PermissionConfig : IEntityTypeConfiguration<Domain.Models.Permission.Entities.Permission>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.Permission.Entities.Permission> builder)
        {
            builder.Property(t => t.Title).HasConversion<TitleConversion>().HasMaxLength(250).IsRequired();
        }
    }
}
