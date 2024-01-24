using AYweb.Domain.Common.Repositories;
using AYweb.Domain.Models.Role.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Domain.Models.Role.Repositories
{
    public interface IRolePermissionRepository:IRepository<Role_Permission>
    {
    }
}
