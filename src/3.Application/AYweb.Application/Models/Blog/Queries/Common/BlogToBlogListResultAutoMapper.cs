using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Blog.Queries.Common
{
    public class BlogToBlogResultAutoMapper : Profile
    {
        public BlogToBlogResultAutoMapper()
        {
            CreateMap<Domain.Models.Blog.Entities.Blog, BlogResult>().ReverseMap();
        }
    }
}
