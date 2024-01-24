using AYweb.Domain.Common.Repositories;
using AYweb.Domain.Models.Blog.Entities;

namespace AYweb.Domain.Models.Academy.Repositories
{
    public interface IAcademyRepository: IRepository<Academy.Entities.Academy>
    {
        void ChangeName(string name);
        void ChangeTeamCount(int teamCount);
        void ChangeProjectCount(int projectCount);
        Entities.Academy Get();
    }
}
