using AIPFramework.Queries;
using AYweb.Application.Models.Plan.Queries.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Plan.Queries.GetPlan
{
    public class GetPlanQuery:IQuery<PlanResult>
    {
        public long Id { get; set; }
    }
}
