using AYweb.Domain.Models.Order.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Infrastructure.Models.Order.Configs;

public class OrderLineConfig : IEntityTypeConfiguration<OrderLine>
{
    public void Configure(EntityTypeBuilder<OrderLine> builder)
    {
        builder.HasOne(t => t.Product);
        builder.HasOne(t => t.Order);

    }
}
