using AIPFramework.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Domain.Models.Academy.Entities.Configs
{
    public class AcademyConfig : IEntityTypeConfiguration<Academy>
    {
        public void Configure(EntityTypeBuilder<Academy> builder)
        {
            builder.HasData(new Academy("AyWeb", 2, 3));

            builder.HasKey(x => x.Id);
            
            builder.Property(t=>t.Name).HasMaxLength(250).IsRequired();
            builder.Property(t=>t.ProjectCount).IsRequired();
            builder.Property(t=>t.TeamCount).IsRequired();            
        }
    }
}
