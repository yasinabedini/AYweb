using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Domain.Models.Plan.ValueObjects.Conversion
{
    public class PlanTypeConversion : ValueConverter<PlanType, string>
    {
        public PlanTypeConversion() : base(c => c.Value, c => PlanType.FromString(c)) { }
    }
}
