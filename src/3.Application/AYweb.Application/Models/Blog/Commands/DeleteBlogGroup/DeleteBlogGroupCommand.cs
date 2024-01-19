using AIPFramework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Blog.Commands.DeleteBlogGroup
{
    public class DeleteBlogGroupCommand:ICommand
    {
        public long Id { get; set; }
    }
}
