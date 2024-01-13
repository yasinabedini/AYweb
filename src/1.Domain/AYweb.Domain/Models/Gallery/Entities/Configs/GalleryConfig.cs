using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AYweb.Domain.Models.Gallery.Entities.Configs;

public class GalleryConfig : IEntityTypeConfiguration<Gallery>
{
    public void Configure(EntityTypeBuilder<Gallery> builder)
    {        


        builder.Property(t => t.ImageName).HasMaxLength(50).IsRequired();
    }
}
