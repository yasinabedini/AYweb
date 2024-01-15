using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AYweb.Infrastructure.Models.Gallery.Configs;

public class GalleryConfig : IEntityTypeConfiguration<Domain.Models.Gallery.Entities.Gallery>
{
    public void Configure(EntityTypeBuilder<Domain.Models.Gallery.Entities.Gallery> builder)
    {


        builder.Property(t => t.ImageName).HasMaxLength(50).IsRequired();
    }
}
