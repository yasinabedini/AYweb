using AIPFramework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.User.Commands.IsUserExisting
{
    public class IsUserExistingCommand:ICommand<bool>
    {
        public required string PhoneNumber { get; set; }
    }
}
