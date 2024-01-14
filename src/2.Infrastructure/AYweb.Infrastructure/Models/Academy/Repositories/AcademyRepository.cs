using AYweb.Domain.Models.Academy.Repositories;
using AYweb.Infrastructure.Common.Repository;
using AYweb.Infrastructure.Contexts;

namespace AYweb.Infrastructure.Models.Academy.Repositories;

public class AcademyRepository : BaseRepository<Domain.Models.Academy.Entities.Academy>, IAcademyRepository
{
    public AcademyRepository(AyWebDbContext context) : base(context)
    {
    }
}
