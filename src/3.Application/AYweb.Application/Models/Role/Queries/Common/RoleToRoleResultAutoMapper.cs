﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Role.Queries.Common
{
    public class RoleToRoleResultAutoMapper : Profile
    {
        public RoleToRoleResultAutoMapper()
        {
            CreateMap<Domain.Models.Role.Entities.Role, RoleResult>().ReverseMap();
        }
    }
}
