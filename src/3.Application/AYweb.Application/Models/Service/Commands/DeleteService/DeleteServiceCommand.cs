using AIPFramework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Service.Commands.DeleteService
{
    public class DeleteServiceCommand:ICommand
    {
        public long Id { get; set; }
    }
}
