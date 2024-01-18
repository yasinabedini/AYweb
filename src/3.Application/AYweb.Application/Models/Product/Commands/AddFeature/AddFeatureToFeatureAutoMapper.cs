using AutoMapper;
using AYweb.Domain.Models.Product.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Product.Commands.AddFeature
{
    public class AddFeatureToFeatureAutoMapper : Profile
    {
        public AddFeatureToFeatureAutoMapper()
        {
            CreateMap<AddFeatureCommand, Feature>().ReverseMap();
        }
    }
}
