using AYweb.Domain.Common.ValueObjects.Conversion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Domain.Models.Role.Entities.Configs
{
    public class RoleConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Property(t => t.Title).HasConversion<TitleConversion>().HasMaxLength(250).IsRequired();

//            builder.HasMany(t => t.Permissions);
//            
//            builder.HasMany(t => t.Role_Users);
        }
    }
}
