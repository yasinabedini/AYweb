using AIPFramework.Commands;
using AYweb.Domain.Common.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.User.Commands.CounselingUser
{
    public class CounselingUserCommand:ICommand
    {
        public required string UserName { get;  set; }
        public required string PhoneNumber { get;  set; }
        public required string Message { get;  set; }
        public required string Title { get;  set; }
    }
}
