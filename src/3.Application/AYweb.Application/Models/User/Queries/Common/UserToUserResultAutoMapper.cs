using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.User.Queries.Common
{
    public class UserToUserResultAutoMapper : Profile
    {
        public UserToUserResultAutoMapper()
        {
            CreateMap<Domain.Models.User.Entities.User, UserResult>().ReverseMap();
        }
    }
}
