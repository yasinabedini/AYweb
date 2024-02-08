using AIPFramework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.User.Commands.ApprovePhoneNumber
{
    public class ApprovePhoneNumberCommand:ICommand
    {
        public required string  PhoneNumber { get; set; }
    }
}
