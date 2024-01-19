using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Blog.Queries.GetBlogs
{
    public class BlogToBlogListResultAutoMapper:Profile
    {
        public BlogToBlogListResultAutoMapper()
        {
            CreateMap<Domain.Models.Blog.Entities.Blog, BlogListResult>().ReverseMap();
        }
    }
}
