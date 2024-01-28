using AYweb.Domain.Common.ValueObjects;
using AYweb.Domain.Models.Plan.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Plan.Queries.Common
{
    public class PlanResult
    {
        public long  Id { get; set; }

        public required string Title { get;  set; }

        public required string PlanType { get;  init; }

        public int Price { get;  set; }

        public required List<PlanFearureResult> planFeatures { get; set; }
    }
}
