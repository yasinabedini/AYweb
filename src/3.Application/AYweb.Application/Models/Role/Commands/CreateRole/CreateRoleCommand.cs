using AIPFramework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Role.Commands.CreateRole
{
    public class CreateRoleCommand:ICommand<long>
    {
        public required string Title { get; set; }
    }
}
