using AIPFramework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.User.Commands.DeleteAllUserRoles
{
    public class DeleteAllUserRolesCommand:ICommand
    {
        public long UserId { get; set; }
    }
}
