using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Service.Queries.Common
{
    public class SeviceToServiceResultAutoMapper : Profile
    {
        public SeviceToServiceResultAutoMapper()
        {
            CreateMap<Domain.Models.Service.Entities.Service, ServiceResult>().ReverseMap();
        }
    }
}
