using AutoMapper;
using AYweb.Domain.Models.Order.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Order.Queries.GetUserCurrentOrder
{
    public class OrderToOrderResultAutoMapper : Profile
    {
        public OrderToOrderResultAutoMapper()
        {
            CreateMap<OrderResult, Domain.Models.Order.Entities.Order>().ReverseMap();
        }
    }
}
