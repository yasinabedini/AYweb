using AIPFramework.Commands;
using AYweb.Domain.Common.ValueObjects;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Blog.Commands.CreateBlog
{
    public class CreateBlogCommand : ICommand<long>
    {
        public required string Title { get; set; }

        public required string Summary { get; set; }

        public required string Introduction { get; set; }

        public required string Text { get; set; }

        public long AuthorId { get; init; }

        public required string Tags { get; set; }

        public required IFormFile Image { get; set; }
        public required List<IFormFile> Pictures { get; set; }
    }
}
