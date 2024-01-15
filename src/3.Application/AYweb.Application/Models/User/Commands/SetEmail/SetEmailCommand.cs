using AIPFramework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.User.Commands.SetEmail
{
    public class SetEmailCommand:ICommand
    {
        public long Id { get; set; }
        public string Email { get; set; }
    }
}
