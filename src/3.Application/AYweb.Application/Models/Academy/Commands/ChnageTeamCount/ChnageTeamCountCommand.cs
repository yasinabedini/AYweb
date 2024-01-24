using AIPFramework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Academy.Commands.ChnageTeamCount
{
    public class ChnageTeamCountCommand:ICommand
    {
        public int TeamCount { get; set; }
    }
}
