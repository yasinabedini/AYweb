using AIPFramework.Queries;
using AYweb.Application.Models.Role.Queries.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Role.Queries.GetUserRoles
{
    public class GetUserRolesQuery : IQuery<List<RoleResult>>
    {
        public long UserId { get; set; }
    }
}
