using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AYweb.Domain.Models.Service.Entities.Configs;

public class ServiceConfig : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> builder)
    {
        throw new NotImplementedException();
    }
}
