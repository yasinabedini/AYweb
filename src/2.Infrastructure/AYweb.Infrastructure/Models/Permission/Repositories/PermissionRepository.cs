using AYweb.Domain.Models.Permission.Repositories;
using AYweb.Infrastructure.Common.Repository;
using AYweb.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Infrastructure.Models.Permission.Repositories
{
    public class PermissionRepository : BaseRepository<Domain.Models.Permission.Entities.Permission>, IPermissionRepository
    {
        public PermissionRepository(AyWebDbContext context) : base(context)
        {
        }
    }
}
