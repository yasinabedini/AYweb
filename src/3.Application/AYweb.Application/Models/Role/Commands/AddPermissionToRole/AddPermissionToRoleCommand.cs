using AIPFramework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Role.Commands.AddPermissionToRole
{
    public class AddPermissionToRoleCommand:ICommand
    {
        public long RoleId { get; set; }
        public long PermissionId { get; set; }
    }
}
