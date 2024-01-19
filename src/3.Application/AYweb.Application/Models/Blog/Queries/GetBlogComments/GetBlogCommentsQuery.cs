using AIPFramework.Queries;
using AYweb.Application.Models.Blog.Queries.Common;
using AYweb.Application.Models.Blog.Queries.GetComments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Blog.Queries.GetBlogComments
{
    public class GetBlogCommentsQuery:IQuery<List<CommentResult>>
    {
        public long BlogId { get; set; }
    }
}
