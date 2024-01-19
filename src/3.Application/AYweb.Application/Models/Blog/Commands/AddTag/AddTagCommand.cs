using AIPFramework.Commands;
using AYweb.Application.Models.Product.Queries.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Blog.Commands.AddTag
{
    public class AddTagCommand:ICommand
    {
        public long BlogId { get; set; }
        public required string Tag { get; set; }
    }
}
