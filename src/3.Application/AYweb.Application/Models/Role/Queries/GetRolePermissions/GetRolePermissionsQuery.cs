using AIPFramework.Queries;
using AYweb.Application.Models.Permission.Queries.Common;
using AYweb.Application.Models.Role.Queries.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Role.Queries.GetRolePermissions
{
    public class GetRolePermissionsQuery:IQuery<List<PermissionResult>>
    {
        public long Id { get; set; }
    }
}
