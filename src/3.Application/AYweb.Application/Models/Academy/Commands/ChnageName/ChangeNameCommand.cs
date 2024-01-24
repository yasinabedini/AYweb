using AIPFramework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Academy.Commands.ChnageName
{
    public class ChangeNameCommand: ICommand
    {
        public required string Name { get; set; }
    }
}
