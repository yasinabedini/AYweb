using AIPFramework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.User.Commands.ChangeLastName
{
    public class ChangeLastNameCommand:ICommand
    {
        public long Id { get; set; }
        public required string LastName { get; set; }
    }
}
