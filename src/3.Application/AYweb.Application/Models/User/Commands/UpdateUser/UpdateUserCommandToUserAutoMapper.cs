using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.User.Commands.UpdateUser
{
    public class UpdateUserCommandToUserAutoMapper : Profile
    {
        public UpdateUserCommandToUserAutoMapper()
        {
            CreateMap<UpdateUserCommand, Domain.Models.User.Entities.User>().ReverseMap();
        }
    }
}
