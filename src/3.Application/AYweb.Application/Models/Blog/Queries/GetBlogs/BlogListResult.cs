using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Blog.Queries.GetBlogs
{
    public class BlogListResult
    {
        public long Id { get; set; }

        public required string Title { get; set; }

        public required string Summery { get; set; }

        public required string ImageName { get; set; }

        public required string UserName { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
