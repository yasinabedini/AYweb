using AIPFramework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Blog.Commands.AddBlogGroup
{
    public class AddBlogGroupCommand:ICommand
    {
        public required string Title { get; set; }
    }
}
