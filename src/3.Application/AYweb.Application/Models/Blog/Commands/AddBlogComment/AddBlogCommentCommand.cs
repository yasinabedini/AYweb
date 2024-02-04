using AIPFramework.Commands;
using AYweb.Domain.Common.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Blog.Commands.AddBlogComment
{
    public class AddBlogCommentCommand:ICommand
    {
        public required string Text { get;  set; }

        public long BlogId { get;  set; }

        public required string UserName { get;  set; }

        public required string UserPhoneNumber { get;  set; }
    }
}
