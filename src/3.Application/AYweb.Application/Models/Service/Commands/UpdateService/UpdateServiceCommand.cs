using AIPFramework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Service.Commands.UpdateService
{
    public class UpdateServiceCommand:ICommand
    {
        public required Domain.Models.Service.Entities.Service Service{ get; set; }
    }
}
