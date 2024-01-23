using AIPFramework.Commands;
using AYweb.Domain.Models.Role.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Role.Commands.UpdateRole
{
    public class UpdateRoleCommand:ICommand
    {
        public required Domain.Models.Role.Entities.Role Role { get; set; }
    }
}
