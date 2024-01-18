using AutoMapper;
using AYweb.Domain.Models.Product.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Product.Queries.Common
{
    public class ProductToProductResultAutoMapper : Profile
    {
        public ProductToProductResultAutoMapper()
        {
            CreateMap<Domain.Models.Product.Entities.Product, ProductResult>().ReverseMap();
        }
    }
}
