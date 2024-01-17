using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Product.Commands.CreateProduct
{
    public class CreateProductToProductAutoMapper:Profile
    {
        public CreateProductToProductAutoMapper()
        {
            CreateMap<Domain.Models.Product.Entities.Product, CreateProductCommand>().ReverseMap();
        }
    }
}
