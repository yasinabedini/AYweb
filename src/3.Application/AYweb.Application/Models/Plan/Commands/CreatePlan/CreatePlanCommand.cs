using AIPFramework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Plan.Commands.CreatePlan
{
    public class CreatePlanCommand:ICommand
    {
        public required string Title { get; set; }
        public required string PlanType { get; set; }
        public required int Price { get; set; }
    }
}
