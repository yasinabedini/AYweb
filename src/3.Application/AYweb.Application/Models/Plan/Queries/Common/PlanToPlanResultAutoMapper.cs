using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Plan.Queries.Common
{
    public class PlanToPlanResultAutoMapper:Profile
    {
        public PlanToPlanResultAutoMapper()
        {
            CreateMap<Domain.Models.Plan.Entities.Plan, PlanResult>().ReverseMap();
        }
    }
}
