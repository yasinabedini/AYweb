using AIPFramework.Commands;
using AYweb.Domain.Common.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Blog.Commands.CreateBlog
{
    public class CreateBlogCommand : ICommand
    {
        public required string Title { get; set; }

        public required string Summary { get; set; }

        public required string Introduction { get; set; }

        public required string Text { get; set; }

        public long AuthorId { get; init; }

        public required string Tags { get; set; }

        public required string ImageName { get; set; }
    }
}
