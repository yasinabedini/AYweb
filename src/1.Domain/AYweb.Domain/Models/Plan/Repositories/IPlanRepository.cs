using AYweb.Domain.Common.Repositories;
using AYweb.Domain.Models.Blog.Entities;
using AYweb.Domain.Models.Plan.Entities;

namespace AYweb.Domain.Models.Plan.Repositories
{
    public interface IPlanRepository : IRepository<Plan.Entities.Plan>
    {
        List<Plan.Entities.Plan> GetListWithRelations();
        Plan.Entities.Plan GetByIdWithRelations(long id);
    }
}
