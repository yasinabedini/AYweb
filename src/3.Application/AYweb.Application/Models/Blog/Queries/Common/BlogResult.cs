using AYweb.Application.Models.Gallery.Queries.GetGallery;
using AYweb.Application.Models.User.Queries.Common;
using AYweb.Domain.Common.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Blog.Queries.Common
{
    public class BlogResult
    {
        public long Id { get; set; }

        public required string Title { get; set; }

        public required string Introduction { get; set; }

        public required string Text { get; set; }

        public required string Tags { get; set; }

        public required string Summary { get; set; }

        public required string ImageName { get; set; }
        
        public DateTime CreateAt { get; set; }

        public required UserResult Author { get; set; }

        public required List<GalleryResult> Galleries { get; set; }

        public required List<CommentResult> Comments { get; set; }        
    }
}
