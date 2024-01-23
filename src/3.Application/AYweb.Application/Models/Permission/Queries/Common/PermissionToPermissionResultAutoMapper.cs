using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Permission.Queries.Common
{
    public class PermissionToPermissionResultAutoMapper : Profile
    {
        public PermissionToPermissionResultAutoMapper()
        {
            CreateMap<Domain.Models.Permission.Entities.Permission, PermissionResult>().ReverseMap();
        }
    }
}
