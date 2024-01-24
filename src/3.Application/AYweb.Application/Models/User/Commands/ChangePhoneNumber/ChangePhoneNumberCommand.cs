using AIPFramework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.User.Commands.ChangePhoneNumber
{
    public class ChangePhoneNumberCommand:ICommand
    {
        public long Id { get; set; }
        public required string PhoneNumber { get; set; }
    }
}
