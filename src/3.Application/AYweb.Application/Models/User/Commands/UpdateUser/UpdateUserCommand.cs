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
        public long Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }        
        public string? Password { get; set; }
        public string? Email { get; set; }
    }
}
