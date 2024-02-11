using AIPFramework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Blog.Commands.DeleteBlogsGroups
{
    public class DeleteBlogsGroupsCommand:ICommand
    {
        public long BlogId { get; set; }
    }
}
