using AIPFramework.Commands;
using AYweb.Application.Models.User.Queries.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.User.Commands.LoginChack
{
    public class LoginCommand:ICommand<UserResult>
    {
        public string?  Password { get; set; }
        public string? PhoneNumber { get; set; }
        public required string ReturnUrl { get; set; }
        public bool RemmemberMe { get; set; }
    }
}
