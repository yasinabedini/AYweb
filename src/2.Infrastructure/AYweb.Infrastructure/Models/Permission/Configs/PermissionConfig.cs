using AYweb.Domain.Common.ValueObjects.Conversion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Infrastructure.Models.Permission.Configs
{
    public class PermissionConfig : IEntityTypeConfiguration<Domain.Models.Permission.Entities.Permission>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.Permission.Entities.Permission> builder)
        {

            builder.HasKey(t => t.Id).HasAnnotation("DatabaseGenerated", DatabaseGeneratedOption.None);

            builder.Property(t => t.Title).HasConversion<TitleConversion>().HasMaxLength(250).IsRequired();

            builder.HasOne(t => t.Parent);
        }
    }
}
