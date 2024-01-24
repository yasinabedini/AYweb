using AIPFramework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Academy.Commands.ChangeProjectCount
{
    public class ChangeProjectCountCommand:ICommand
    {
        public int ProjectCount { get; set; }
    }
}
