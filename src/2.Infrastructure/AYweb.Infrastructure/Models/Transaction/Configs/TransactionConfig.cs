using AYweb.Domain.Common.ValueObjects.Conversion;
using AYweb.Domain.Models.Transaction.ValueObjects.Conversion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Infrastructure.Models.Transaction.Configs;

public class TransactionConfig : IEntityTypeConfiguration<Domain.Models.Transaction.Entities.Transaction>
{
    public void Configure(EntityTypeBuilder<Domain.Models.Transaction.Entities.Transaction> builder)
    {
        builder.Property(t => t.Status).HasConversion<TransactionStatusConversion>().HasMaxLength(150).IsRequired();

        builder.Property(t => t.Type).HasConversion<TransactionTypeConversion>().HasMaxLength(150).IsRequired();

        builder.Property(t => t.PaymentMethod).HasConversion<PaymentMethodConversion>().HasMaxLength(150).IsRequired();

        builder.Property(t => t.Description).HasConversion<DescriptionConversion>().HasMaxLength(500).IsRequired();

        builder.Property(t => t.TransactionScreenShot).HasMaxLength(200);

        builder.HasOne(t => t.User);

        builder.Property(t => t.Price).IsRequired();


    }
}
