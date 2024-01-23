using AIPFramework.Queries;
using AYweb.Application.Models.Role.Queries.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Role.Queries.GetRole
{
    public class GetRoleQuery:IQuery<RoleResult>
    {
        public long Id { get; set; }
    }
}
