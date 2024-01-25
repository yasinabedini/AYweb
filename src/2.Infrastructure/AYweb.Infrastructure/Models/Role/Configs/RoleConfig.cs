using AYweb.Domain.Common.ValueObjects.Conversion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Infrastructure.Models.Role.Configs
{
    public class RoleConfig : IEntityTypeConfiguration<Domain.Models.Role.Entities.Role>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.Role.Entities.Role> builder)
        {
            builder.Property(t => t.Title).HasConversion<TitleConversion>().HasMaxLength(250).IsRequired();

            builder.HasMany(t => t.Permissions);
                        
            builder.HasMany(t => t.Role_Users);
        }
    }
}
