using AIPFramework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Role.Commands.DeletePermissionFromRole
{
    public class DeletePermissionFromRoleCommand:ICommand
    {
        public long RoleId { get; set; }
        public long PermissionId { get; set; }
    }
}
