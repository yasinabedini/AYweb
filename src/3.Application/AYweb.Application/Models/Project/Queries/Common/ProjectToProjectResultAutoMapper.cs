using AutoMapper;
using AYweb.Domain.Models.Project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Project.Queries.Common;

public class ProjectToProjectResultAutoMapper:Profile
{
    public ProjectToProjectResultAutoMapper()
    {
        CreateMap<Domain.Models.Project.Entities.Project,ProjectResult>().ReverseMap();
    }
}
