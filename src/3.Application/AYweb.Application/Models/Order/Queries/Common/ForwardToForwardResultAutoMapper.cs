using AutoMapper;
using AYweb.Domain.Models.Order.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Order.Queries.Common
{
    public class ForwardToForwardResultAutoMapper:Profile
    {
        public ForwardToForwardResultAutoMapper()
        {
            CreateMap<Forward, ForwardResult>().ReverseMap();
        }
    }
}
