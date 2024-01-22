using AIPFramework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Plan.Commands.AddPlanToUser
{
    public class AddPlanToUserCommand:ICommand
    {
        public long UserId { get; set; }
        public long PlanId { get; set; }
        public long TransactionId { get; set; }
    }
}
