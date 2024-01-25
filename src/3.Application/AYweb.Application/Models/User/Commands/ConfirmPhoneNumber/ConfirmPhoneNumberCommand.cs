using AIPFramework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.User.Commands.ConfirmPhoneNumber
{
    public class ConfirmPhoneNumberCommand:ICommand<bool>
    {
        public required string PhoneNumber { get; set; }
        public  string? Code { get; set; }
        public  string? VereficationCode { get; set; }
    }
}
