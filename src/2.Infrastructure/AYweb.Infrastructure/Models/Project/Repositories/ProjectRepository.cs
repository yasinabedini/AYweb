using AYweb.Domain.Models.Plan.Repositories;
using AYweb.Domain.Models.Project.Repositories;
using AYweb.Infrastructure.Common.Repository;
using AYweb.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Infrastructure.Models.Project.Repositories
{
    public class ProjectRepository : BaseRepository<Domain.Models.Project.Entities.Project>, IProjectRepository
    {
        public ProjectRepository(AyWebDbContext context) : base(context)
        {
        }
    }
}
