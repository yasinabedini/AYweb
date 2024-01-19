using AutoMapper;
using AYweb.Domain.Models.Blog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Blog.Commands.CreateBlog
{
    public class CreateBlogToBlogAutoMapper : Profile
    {
        public CreateBlogToBlogAutoMapper()
        {
            CreateMap<CreateBlogCommand,Domain.Models.Blog.Entities.Blog>().ReverseMap();
        }
    }
}
