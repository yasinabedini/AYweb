﻿using AYweb.Domain.Common.ValueObjects.Conversion;
using AYweb.Domain.Models.Order.ValueObjects.Conversion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Domain.Models.Order.Entities.Configs
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(t => t.Notes).HasConversion<DescriptionConversion>().HasMaxLength(500).IsRequired();
            
            builder.Property(t => t.OrderStatus).HasConversion<OrderStatusConversion>().HasMaxLength(100).IsRequired();

            builder.HasMany(t => t.OrderLines);

            //builder.HasOne(t => t.Forward).WithOne(t=>t.Order).HasForeignKey("ForwardId");

            builder.HasOne(t => t.User);
        }
    }
}
