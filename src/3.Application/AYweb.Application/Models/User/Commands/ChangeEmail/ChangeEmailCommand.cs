using AIPFramework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.User.Commands.ChangeEmail
{
    public class ChangeEmailCommand:ICommand
    {
        public long Id { get; set; }
        public required string Email { get; set; }
    }
}
