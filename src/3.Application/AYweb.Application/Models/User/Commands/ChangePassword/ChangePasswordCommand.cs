using AIPFramework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AYweb.Application.Models.User.Commands.ChangePassword
{
    public class ChangePasswordCommand : AIPFramework.Commands.ICommand
    {
        public long Id { get; set; }
        public required string OldPassword { get; set; }
        public required string Password { get; set; }
        public required string Re_Password { get; set; }
    }
}
