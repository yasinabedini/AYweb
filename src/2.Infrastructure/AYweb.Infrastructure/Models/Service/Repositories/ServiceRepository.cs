using AYweb.Domain.Models.Service.Repositories;
using AYweb.Infrastructure.Common.Repository;
using AYweb.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Infrastructure.Models.Service.Repositories
{
    public class ServiceRepository : BaseRepository<Domain.Models.Service.Entities.Service>, IServiceRepository
    {
        public ServiceRepository(AyWebDbContext context) : base(context)
        {
        }
    }
}
