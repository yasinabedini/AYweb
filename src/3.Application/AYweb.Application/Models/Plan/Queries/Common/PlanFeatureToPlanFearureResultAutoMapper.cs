using AutoMapper;
using AYweb.Domain.Models.Plan.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Plan.Queries.Common
{
    public class PlanFeatureToPlanFearureResultAutoMapper:Profile
    {
        public PlanFeatureToPlanFearureResultAutoMapper() {
            CreateMap<PlanFeature, PlanFearureResult>().ReverseMap();
        }
    }
}
