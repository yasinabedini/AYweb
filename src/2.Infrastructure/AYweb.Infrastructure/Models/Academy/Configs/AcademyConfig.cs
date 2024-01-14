using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AYweb.Infrastructure.Models.Academy.Configs
{
    public class AcademyConfig : IEntityTypeConfiguration<Academy>
    {
        public void Configure(EntityTypeBuilder<Academy> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(t => t.Name).HasMaxLength(250).IsRequired();
            builder.Property(t => t.ProjectCount).IsRequired();
            builder.Property(t => t.TeamCount).IsRequired();
        }
    }
}
