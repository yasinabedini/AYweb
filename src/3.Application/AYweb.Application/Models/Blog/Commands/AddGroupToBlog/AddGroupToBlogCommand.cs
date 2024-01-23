using AIPFramework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Blog.Commands.AddGroupToBlog
{
    public class AddGroupToBlogCommand : ICommand
    {
        public int BlogId { get; set; }
        public int GroupId { get; set; }
    }
}
