using AIPFramework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Permission.Commands.CheckPermission
{
    public class CheckPermissionCommand:ICommand<bool>
    {
        public long UserId { get; set; }
        public long PermissionId { get; set; }
    }
}
