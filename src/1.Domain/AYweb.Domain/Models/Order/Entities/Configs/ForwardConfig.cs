using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AYweb.Domain.Models.Order.Entities.Configs
{
    public class ForwardConfig : IEntityTypeConfiguration<Forward>
    {
        public void Configure(EntityTypeBuilder<Forward> builder)
        {
            builder.Property(t => t.Address).HasMaxLength(500).IsRequired();

            builder.Property(t => t.City).HasMaxLength(100).IsRequired();

            builder.Property(t => t.Province).HasMaxLength(100).IsRequired();

            builder.Property(t => t.PostalCode).HasMaxLength(40).IsRequired();

            builder.Property(t => t.TrackingCode).HasMaxLength(40).IsRequired();

            builder.Property(t => t.TransfereeName).HasMaxLength(100).IsRequired();
                        
        }
    }
}
