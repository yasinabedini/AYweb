using AIPFramework.Queries;
using AYweb.Application.Models.Plan.Queries.Common;
using AYweb.Domain.Models.User.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Plan.Queries.GetCurrentUserPlan
{
    public class GetCurrentUserActivePlanQuery : IQuery<PlanResult>
    {
    }
}
