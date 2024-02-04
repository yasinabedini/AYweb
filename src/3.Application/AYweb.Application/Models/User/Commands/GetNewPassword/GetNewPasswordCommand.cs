using AIPFramework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.User.Commands.GetNewPassword
{
    public class GetNewPasswordCommand:ICommand
    {
        public required string PhoneNumber { get; set; }
    }
}
