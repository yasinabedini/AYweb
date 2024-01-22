using AIPFramework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Plan.Commands.UpdatePlan
{
    public class UpdatePlanCommand:ICommand
    {
        public required Domain.Models.Plan.Entities.Plan Plan { get; set; }
    }
}
