using AIPFramework.Commands;
using AYweb.Domain.Models.Blog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Blog.Commands.UpdateBlog
{
    public class UpdateBlogCommand:ICommand
    {
        public required Domain.Models.Blog.Entities.Blog Blog { get; set; }
    }
}
