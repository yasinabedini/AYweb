using AYweb.Domain.Models.Plan.Repositories;
using AYweb.Infrastructure.Common.Repository;
using AYweb.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Infrastructure.Models.Plan.Repositories
{
    public class PlanRepository : BaseRepository<Domain.Models.Plan.Entities.Plan>, IPlanRepository
    {
        private readonly AyWebDbContext _context;
        public PlanRepository(AyWebDbContext context) : base(context)
        {
                _context = context;
        }

        public Domain.Models.Plan.Entities.Plan GetByIdWithRelations(long id)
        {
            return _context.Plans.Include(t => t.planFeatures).First(t=>t.Id==id);
        }

        public List<Domain.Models.Plan.Entities.Plan> GetListWithRelations()
        {
            return _context.Plans.Include(t => t.planFeatures).ToList();
        }
    }
}
