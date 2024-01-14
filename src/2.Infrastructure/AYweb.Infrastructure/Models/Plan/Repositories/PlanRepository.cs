using AYweb.Domain.Models.Plan.Repositories;
using AYweb.Infrastructure.Common.Repository;
using AYweb.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Infrastructure.Models.Plan.Repositories
{
    public class PlanRepository : BaseRepository<Domain.Models.Plan.Entities.Plan>, IPlanRepository
    {
        public PlanRepository(AyWebDbContext context) : base(context)
        {
        }
    }
}
