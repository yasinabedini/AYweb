using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AYweb.Infrastructure.Models.Academy.Configs
{
    public class AcademyConfig : IEntityTypeConfiguration<Domain.Models.Academy.Entities.Academy>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.Academy.Entities.Academy> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(t => t.Name).HasMaxLength(250).IsRequired();
            builder.Property(t => t.ProjectCount).IsRequired();
            builder.Property(t => t.TeamCount).IsRequired();
        }
    }
}
