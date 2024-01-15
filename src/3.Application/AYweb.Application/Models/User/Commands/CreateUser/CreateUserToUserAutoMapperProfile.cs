using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.User.Commands.CreateUser
{
    public class CreateUserToUserAutoMapperprofile : Profile
    {
        public CreateUserToUserAutoMapperprofile()
        {
            CreateMap<CreateUserCommand, Domain.Models.User.Entities.User>().ReverseMap();
        }
    }
}
