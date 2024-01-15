using AIPFramework.Commands;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.User.Commands.ChangeFirstName
{
    public class ChangeFirstNameCommand:ICommand
    {
        public long Id { get; set; }
        public required string FirstName { get; set; }
    }
}
