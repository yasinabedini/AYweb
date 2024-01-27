using AutoMapper;
using AYweb.Domain.Models.Blog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Blog.Queries.Common
{
    public class BlogGroupToBlogGroupResultAutoMapper : Profile
    {
        public BlogGroupToBlogGroupResultAutoMapper()
        {
            CreateMap<BlogGroup, BlogGroupResult>().ReverseMap();
        }
    }
}
