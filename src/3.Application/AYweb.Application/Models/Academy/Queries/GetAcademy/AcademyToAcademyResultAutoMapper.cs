using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Academy.Queries.GetAcademy
{
    public class AcademyToAcademyResultAutoMapper : Profile
    {
        public AcademyToAcademyResultAutoMapper()
        {
            CreateMap<Domain.Models.Academy.Entities.Academy, AcademyResult>().ReverseMap();
        }
    }
}
