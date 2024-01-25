using AYweb.Domain.Common.ValueObjects.Conversion;
using AYweb.Domain.Models.Order.ValueObjects.Conversion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Infrastructure.Models.Order.Configs
{
    public class OrderConfig : IEntityTypeConfiguration<Domain.Models.Order.Entities.Order>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.Order.Entities.Order> builder)
        {
            builder.Property(t => t.Notes).HasConversion<DescriptionConversion>().HasMaxLength(500);

            builder.Property(t => t.OrderStatus).HasConversion<OrderStatusConversion>().HasMaxLength(100).IsRequired();

            builder.HasMany(t => t.OrderLines);

            builder.HasOne(t => t.Forward).WithOne(t=>t.Order);

            builder.HasOne(t => t.User);
        }
    }
}
