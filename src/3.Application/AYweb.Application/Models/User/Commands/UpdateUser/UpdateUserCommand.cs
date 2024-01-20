using AIPFramework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.User.Commands.UpdateUser
{
    public class UpdateUserCommand:ICommand
    {
        public required Domain.Models.User.Entities.User User { get; set; }
    }
}
