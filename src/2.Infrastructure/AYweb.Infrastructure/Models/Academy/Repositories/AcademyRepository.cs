using AYweb.Domain.Models.Academy.Repositories;
using AYweb.Infrastructure.Common.Repository;
using AYweb.Infrastructure.Contexts;

namespace AYweb.Infrastructure.Models.Academy.Repositories;

public class AcademyRepository : BaseRepository<Domain.Models.Academy.Entities.Academy>, IAcademyRepository
{
    private readonly AyWebDbContext _context;
    public AcademyRepository(AyWebDbContext context) : base(context)
    {
        _context = context;
    }

    public void ChangeName(string name)
    {
        var academy = Get();
        academy.ChangeName(name);
        Update(academy);
    }

    public void ChangeProjectCount(int projectCount)
    {
        var academy = Get();
        academy.ChangeProjectCount(projectCount);
        Update(academy);
    }

    public void ChangeTeamCount(int teamCount)
    {
        var academy = Get();
        academy.ChangeTeamCount(teamCount);
        Update(academy);
    }

    public Domain.Models.Academy.Entities.Academy Get()
    {
        return _context.Academies.First();
    }
}
