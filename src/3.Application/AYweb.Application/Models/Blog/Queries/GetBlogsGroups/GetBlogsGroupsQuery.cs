using AIPFramework.Queries;
using AYweb.Application.Models.Blog.Queries.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AYweb.Application.Models.Blog.Queries.GetBlogsGroups
{
    public class GetBlogsGroupsQuery:IQuery<List<BlogGroupResult>>
    {
        public long Id { get; set; }
    }
}
